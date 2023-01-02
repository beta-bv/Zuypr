using Controller;
using Microsoft.Maui.Storage;
using Model;
using Controller;
using System.Linq.Expressions;
using Microsoft.Maui.Storage;
using System.Net;
using Controller.Platforms;

namespace View.Pages;

public partial class Settings : ContentPage
{
    private bool _editIsClicked = false;
    private bool _editPIsClicked = false;
    private bool _deleteAccountClicked = false;
    private List<City> _validCities;
    public Settings()
    {
        InitializeComponent();
        EmailField.Text = Auth.User.Email;
        _validCities = Model.City.ValidCities;
        ListViewSelectedCities.IsEnabled = false;
        ListViewSelectedCities.ItemsSource = Auth.User.Cities.Select(a => a.Name);
    }

    private void Logout(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new LaunchScreen();

    }
    private void onDeleteClicked(Object sender, EventArgs e)
    {
        _deleteAccountClicked = !_deleteAccountClicked;
        if (_deleteAccountClicked) 
        {
            DestroyConfirm.IsVisible = true;
            DestroyCancel.IsVisible = true;
        }

    }
    private void onDeleteConfirmClicked(Object sender, EventArgs e)
    {
        Application.Current.MainPage = new LaunchScreen();
        UserDatabaseOperations.RemoveUserFromDatabase();
    }

    private void onCancelDeleteClicked(Object sender, EventArgs e)
    {
        _deleteAccountClicked = !_deleteAccountClicked;
        if (!_deleteAccountClicked)
        {
            DestroyConfirm.IsVisible = false;
            DestroyCancel.IsVisible = false;
        }
    }

    /// <summary>
    /// slaat de emailwijzigingen op
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEmailSavedClicked(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if(RepeatEmailField.Text == null || EmailField.Text == null)
            {
                throw new Exception("Email adress fields cannot be empty");
            }

            if(EmailField.Text.Equals(Auth.User.Email) || RepeatEmailField.Text.Equals(Auth.User.Email))
            {
                throw new Exception("Your new Email may not be your old Email");
            }

            if (RepeatEmailField.Text.Equals(EmailField.Text))
            {
                temp.Email = EmailField.Text.Trim();
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                EmailEditCancelBtn.Text = "Edit";
                RepeatEmailField.Text = "";
                EmailField.Text = Auth.User.Email;
                EmailField.IsEnabled = false;
                RepeatEmailField.IsVisible = false;
                SaveEmailBtn.IsVisible = false;
                _editIsClicked = false;
                ErrorFrameEditPage.IsVisible = false;
            }
            else
            {
                throw new Exception("The new email and old email are not the same");
            }
        }

        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    /// <summary>
    /// zorgt ervoor dat de user zijn of haar email kan aanpassen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEditEmailClicked(object sender, EventArgs e)
    {
        _editIsClicked = !_editIsClicked;
        if (_editIsClicked)
        {
            EmailEditCancelBtn.Text = "Cancel";
            EmailField.Text = "";
            EmailField.IsEnabled = true;
            RepeatEmailField.IsVisible = true;
            SaveEmailBtn.IsVisible = true;
        }
        else
        {
            EmailEditCancelBtn.Text = "Edit";
            RepeatEmailField.Text = "";
            EmailField.Text = Auth.User.Email;
            EmailField.IsEnabled = false;
            RepeatEmailField.IsVisible = false;
            SaveEmailBtn.IsVisible = false;
        }
    }
    private void OnEditPasswordClicked(object sender, EventArgs e)
    {
        _editPIsClicked = !_editPIsClicked;
        if (_editPIsClicked)
        {
            PasswordEditCancelBtn.Text = "Cancel";
            PasswordField.IsVisible = true;
            RepeatPasswordField.IsVisible = true;
            SavePasswordBtn.IsVisible = true;
            OldPasswordField.IsVisible = true;
        }
        else
        {
            PasswordEditCancelBtn.Text = "Edit";
            PasswordField.Text = "";
            RepeatPasswordField.Text = "";
            PasswordField.IsVisible = false;
            RepeatPasswordField.IsVisible = false;
            SavePasswordBtn.IsVisible = false;
            OldPasswordField.IsVisible = false;
        }
    }
    private void OnPasswordSavedClicked(object sender, EventArgs e)
    {
        try
        {
            User temp = Auth.User;
            if(PasswordField.Text == null || RepeatPasswordField.Text == null || OldPasswordField.Text == null)
            {
                throw new Exception("Password fields cannot be empty");
            }
            if (!PasswordField.Text.Equals(RepeatPasswordField.Text))
            {
                throw new Exception("new passwords are not the same");
            }
            if (OldPasswordField.Text.Equals(RepeatPasswordField.Text)) 
            {
                throw new Exception("Your new password cannot be your old password");
            }
            if(!User.ComparePasswords(User.HashString(OldPasswordField.Text), Auth.User.Password))
            {
                throw new Exception("Old password is not correct");
            }

            if (PasswordField.Text.Equals(RepeatPasswordField.Text) && User.ComparePasswords(User.HashString(OldPasswordField.Text), Auth.User.Password)) 
            {
                temp.Password = PasswordField.Text;
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                PasswordEditCancelBtn.Text = "Edit";
                OldPasswordField.Text = "";
                PasswordField.Text = "";
                RepeatPasswordField.Text = "";
                OldPasswordField.IsVisible = false;
                RepeatPasswordField.IsVisible = false;
                PasswordField.IsVisible = false;
                SavePasswordBtn.IsVisible = false;
                _editPIsClicked = false;
                ErrorFrameEditPage.IsVisible = false;
            }
        }
        catch(Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    private async void FileOpenBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            {
                    FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                    if (photo != null)  
                    {
                    // save the file into local storage
                    string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                    string localFilePath = Path.Combine(Path.Combine(wanted_path, "Zuypr\\Assets"), photo.FileName);    //path om in op te slaan werkt niet, en moet naar de db gaan pushen

                        using Stream sourceStream = await photo.OpenReadAsync();
                        using FileStream localFileStream = File.OpenWrite(localFilePath);

                        await sourceStream.CopyToAsync(localFileStream);
                    }
                }
            }
        catch(Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;

        }
    }

    private void maxAge_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            User tempUser = Auth.User;
            int maxAgeParsed = Int32.Parse(maxAge.Text);
            tempUser.MaximumpreferredAge = maxAgeParsed;
            UserDatabaseOperations.UpdateUserInDatabase(tempUser, Auth.User);
            ErrorFrameEditPage.IsVisible = false;
        }
        catch(FormatException fe)
        {
        }
        catch(Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    private void minAge_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            User tempUser = Auth.User;
            int minAgeParsed = Int32.Parse(minAge.Text);
            tempUser.MinimumpreferredAge = minAgeParsed;
            UserDatabaseOperations.UpdateUserInDatabase(tempUser, Auth.User);
            ErrorFrameEditPage.IsVisible = false;
        }
        catch (FormatException){}
        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        ListViewCities.ItemsSource = Model.City.getCitySearchResult(searchBar.Text, 10).Select(a => a.Name);
    }

    private void AddButtonList_Pressed(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if (!temp.Cities.Select(a => a.Name).Contains(ListViewCities.SelectedItem.ToString()))
            {
                temp.Cities.Add(new City(ListViewCities.SelectedItem.ToString()));
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                ListViewSelectedCities.IsEnabled = false;
                ListViewSelectedCities.ItemsSource = null;
                ListViewSelectedCities.ItemsSource = Auth.User.Cities.Select(a => a.Name);
            }
        }
        catch (NullReferenceException) { }
    }

    private void RemoveButtonList_Pressed(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if (temp.Cities.Remove(temp.Cities.Where(a => a.Name.Equals(ListViewCities.SelectedItem.ToString())).FirstOrDefault()))
            {
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                ListViewSelectedCities.IsEnabled = false;
                ListViewSelectedCities.ItemsSource = null;
                ListViewSelectedCities.ItemsSource = Auth.User.Cities.Select(a => a.Name);
            }
        }
        catch (NullReferenceException) { }
    }
}