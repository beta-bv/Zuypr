using Controller;
using Microsoft.Maui.Storage;
using Model;
using System.Linq.Expressions;
using Microsoft.Maui.Storage;
namespace View.Pages;

public partial class Settings : ContentPage
{
    private bool _editIsClicked = false;
    private bool _editPIsClicked = false;
    private bool _deleteAccountClicked = false;
    public Settings()
    {
        InitializeComponent();
        EmailField.Text = Auth.getUser().Email;
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
            ErrorFrameEditPage.IsVisible=false;
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Image Picker",
                FileTypes = FilePickerFileType.Images,
            });
            if (result == null)
            {
                throw new Exception("could not get Image");
            }
            else
            {
                var stream = await result.OpenReadAsync();
                ImageSource image = ImageSource.FromStream(() => stream);
                
            }
        }
        catch(Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;

        }
    }
}