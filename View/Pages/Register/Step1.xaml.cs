using Model;
using Controller;
using Controller.Platforms;

namespace View.Pages.Register;

public partial class Step1 : ContentPage
{
    public static User User { get; set; }
    private int _atleast1city = 0;
    private int _minAgeParsed;
    private int _maxAgeParsed;

    public Step1(User user)
    {
        InitializeComponent();
        BindingContext = this;
        User = user;
    }

    private async void Next(object sender, EventArgs e)
    {
        if ((_minAgeParsed != 0 && _minAgeParsed >= 18) && (_maxAgeParsed != 0 && _maxAgeParsed < 120) && _atleast1city > 0)
        {
            await Navigation.PushAsync(new Step2());
        }
        else
        {
            ErrorFrameEditPage.IsVisible = true;
            ErrorLabelEditPage.Text = "You need to select a city and select a preferred age range to continue";
        }
    }
    private void SearchBar_TextChanged_S1(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        ListViewCities_S1.ItemsSource = Model.City.getCitySearchResult(searchBar.Text, 10).Select(a => a.Name); 
    }
    private void AddButtonList_Pressed_S1(object sender, EventArgs e)
    {
        try
        {
            if (!Auth.User.Cities.Select(a => a.Name).Contains(ListViewCities_S1.SelectedItem.ToString()))
            {
                ErrorFrameEditPage.IsVisible = false;
                Auth.User.Cities.Add(new City(ListViewCities_S1.SelectedItem.ToString()));
                //UserDatabaseOperations.UpdateUserInDatabase(Auth.User, Auth.User);   //fix dit jonguh
                ListViewSelectedCities_S1.IsEnabled = false;
                ListViewSelectedCities_S1.ItemsSource = null;
                ListViewSelectedCities_S1.ItemsSource = Auth.User.Cities.Select(a => a.Name);
                _atleast1city++;
            }
        }
        catch (NullReferenceException nre) {
            ErrorFrameEditPage.IsVisible = true;
            ErrorLabelEditPage.Text = "You need to select a city before you can add or remove it";
        }
    }

    private void RemoveButtonList_Pressed_S1(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if (temp.Cities.Remove(temp.Cities.Where(a => a.Name.Equals(ListViewCities_S1.SelectedItem.ToString())).FirstOrDefault()))
            {
                //UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User); //fixung
                ListViewSelectedCities_S1.IsEnabled = false;
                ListViewSelectedCities_S1.ItemsSource = null;
                ListViewSelectedCities_S1.ItemsSource = Auth.User.Cities.Select(a => a.Name);
                _atleast1city--;
            }
        }
        catch (NullReferenceException) { }
    }
    private void maxAge_TextChanged_S1(object sender, TextChangedEventArgs e)
    {
        try
        {
            _maxAgeParsed = Int32.Parse(maxAge.Text);
            Auth.User.MaximumpreferredAge = _maxAgeParsed;
            //UserDatabaseOperations.UpdateUserInDatabase(tempUser, Auth.User);    //fixuh
            ErrorFrameEditPage.IsVisible = false;
        }
        catch (FormatException fe)
        {
        }
        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

    private void minAge_TextChanged_S1(object sender, TextChangedEventArgs e)
    {
        try
        {
            _minAgeParsed = Int32.Parse(minAge.Text);
            Auth.User.MinimumpreferredAge = _minAgeParsed;
            //UserDatabaseOperations.UpdateUserInDatabase(tempUser, Auth.User); //fixxuh
            ErrorFrameEditPage.IsVisible = false;
        }
        catch (FormatException) { }
        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }

}