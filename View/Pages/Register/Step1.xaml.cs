using Model;
using Controller;
using Controller.Platforms;

namespace View.Pages.Register;

public partial class Step1 : ContentPage
{
    public static User User { get; set; }

    public Step1(User user)
    {
        User = user;
        InitializeComponent();
        BindingContext = this;
    }

    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step2());
    }
    private void SearchBar_TextChanged_S1(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        ListViewCities_S1.ItemsSource = Model.City.getCitySearchResult(searchBar.Text).Select(a => a.Name); 
    }
    private void AddButtonList_Pressed_S1(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if (!temp.Cities.Select(a => a.Name).Contains(ListViewCities_S1.SelectedItem.ToString()))
            {
                temp.Cities.Add(new City(ListViewCities_S1.SelectedItem.ToString()));
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                ListViewSelectedCities_S1.IsEnabled = false;
                ListViewSelectedCities_S1.ItemsSource = null;
                ListViewSelectedCities_S1.ItemsSource = Auth.User.Cities.Select(a => a.Name);
            }
        }
        catch (NullReferenceException) { }
    }

    private void RemoveButtonList_Pressed_S1(object sender, EventArgs e)
    {
        User temp = Auth.User;
        try
        {
            if (temp.Cities.Remove(temp.Cities.Where(a => a.Name.Equals(ListViewCities_S1.SelectedItem.ToString())).FirstOrDefault()))
            {
                UserDatabaseOperations.UpdateUserInDatabase(temp, Auth.User);
                ListViewSelectedCities_S1.IsEnabled = false;
                ListViewSelectedCities_S1.ItemsSource = null;
                ListViewSelectedCities_S1.ItemsSource = Auth.User.Cities.Select(a => a.Name);
            }
        }
        catch (NullReferenceException) { }
    }
}