using Controller;
using Microsoft.Maui.Storage;
using Model;
using System.Linq.Expressions;
using Microsoft.Maui.Storage;
using System.Net;

namespace View.Pages;

public partial class Settings : ContentPage
{
    private bool _editIsClicked = false;
    private bool _editPIsClicked = false;
    private bool _deleteAccountClicked = false;
    private List<string> ValidCities;
    public Settings()
    {
        InitializeComponent();
        EmailField.Text = Auth.getUser().Email;
        ValidCities = Model.Location.GetValidCities();
        ListViewSelectedCities.ItemsSource = Auth.getUser().Cities;
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
        Auth.setUser(null);
        Application.Current.MainPage = new LaunchScreen();
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
        User temp = Auth.getUser();
        try
        {
            if(RepeatEmailField.Text == null || EmailField.Text == null)
            {
                throw new Exception("Email adress fields cannot be empty");
            }

            if(EmailField.Text.Equals(Auth.getUser().Email) || RepeatEmailField.Text.Equals(Auth.getUser().Email))
            {
                throw new Exception("Your new Email may not be your old Email");
            }

            if (RepeatEmailField.Text.Equals(EmailField.Text))
            {
                temp.Email = EmailField.Text.Trim();
                Auth.setUser(temp);
                EmailEditCancelBtn.Text = "Edit";
                RepeatEmailField.Text = "";
                EmailField.Text = Auth.getUser().Email;
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
            EmailField.Text = Auth.getUser().Email;
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
            User temp = Auth.getUser();
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
            if(!User.ComparePasswords(User.HashString(OldPasswordField.Text), Auth.getUser().Password))
            {
                throw new Exception("Old password is not correct");
            }

            if (PasswordField.Text.Equals(RepeatPasswordField.Text) && User.ComparePasswords(User.HashString(OldPasswordField.Text), Auth.getUser().Password)) 
            {
                temp.Password = PasswordField.Text; 
                Auth.setUser(temp);
                PasswordEditCancelBtn.Text = "Edit";
                PasswordField.Text = "";
                RepeatPasswordField.Text = "";
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
            User tempUser = Auth.getUser();
            int maxAgeParsed = Int32.Parse(maxAge.Text);
            tempUser.MaximumpreferredAge = maxAgeParsed;
            Auth.setUser(tempUser);
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
            User tempUser = Auth.getUser();
            int minAgeParsed = Int32.Parse(minAge.Text);
            tempUser.MinimumpreferredAge = minAgeParsed;
            Auth.setUser(tempUser);
            ErrorFrameEditPage.IsVisible = false;
        }
        catch (FormatException)
        {
        }
        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        ListViewCities.ItemsSource = Model.Location.getCitySearchResult(searchBar.Text);
    }

    private void AddButtonList_Pressed(object sender, EventArgs e)
    {
        User temp = Auth.getUser();
        if (!temp.Cities.Contains(ListViewCities.SelectedItem.ToString()))
        {
            temp.Cities.Add(ListViewCities.SelectedItem.ToString());
            Auth.setUser(temp);
            ListViewSelectedCities.ItemsSource = null;
            ListViewSelectedCities.ItemsSource = Auth.getUser().Cities;
        } 
    }

    private void RemoveButtonList_Pressed(object sender, EventArgs e)
    {
        User temp = Auth.getUser();
        if (temp.Cities.Remove(ListViewCities.SelectedItem.ToString()))
        {
            Auth.setUser(temp);
            ListViewSelectedCities.ItemsSource = null;
            ListViewSelectedCities.ItemsSource = Auth.getUser().Cities;
        }
    }
}