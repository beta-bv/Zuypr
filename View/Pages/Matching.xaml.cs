using Model;
using System.Text.RegularExpressions;
//using static Java.Util.Jar.Attributes;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public User Match { get; }
    public List<Drink> Drinks { get; set; }
    public List<User> Users { get; set; }
    public Matching()
    {
        Match = Controller.Auth.getUser();
        Drinks = Match.GetFavourites();
        InitializeComponent();
        if (Drinks.Count < 2)
        {
            favorite.Text = "Favourite beverage:";
        }
        BindingContext = this;
    }
    public Matching(User user) {
        Match = user;
        Drinks = Match.GetFavourites();
        InitializeComponent();
        if (Drinks.Count < 2)
        {
            favorite.Text = "Favourite beverage:";
        }
        BindingContext = this;
    }

    public Matching(List<User> users) {
        Match = users[0];
        Users = users;
        Drinks = Match.GetFavourites();
        InitializeComponent();
        if (Drinks.Count < 2)
        {
            favorite.Text = "Favourite beverage:";
        }
        BindingContext = this;
    }
    private void Yes_Clicked(object sender, EventArgs e)
    {
        var temp = (Button)sender;
        //if (Application.Current != null)
        //{
        //    Application.Current.MainPage.Navigation.PushAsync(new PopUp());
        //};

        PopDieShitUp.IsVisible = true;
        // Show next person
        // If match show Profile card and chat button
        // Update List
        // Set Database Match and Chat
    }
    private void No_Clicked(object sender, EventArgs e)
    {
        var temp = (Button)sender;
        // Show next person
        // Update List
    }
}