using Model;
using Controller;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public static List<User> PotentionalMatches => Filter.FilteredPotentionalMatches;
    public static Queue<User> UsersQue = new Queue<User>(PotentionalMatches);
    public List<Drink> Drinks { get; set; }

    public User PotentionalMatch { get; set; }
    public static Model.Match CurrentMatch;

    public Matching()
    {
        if (UsersQue.Count() == 0)
        {
            NoMatches.IsVisible = true;
        }
        else
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.GetFavourites();
        }

        InitializeComponent();
        BindingContext = this;
    }

    private void NextUser()
    {
        if (UsersQue.Count() > 0)
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.GetFavourites();

            //Changes the labels on the screen to the current user
            MatchName.Text = PotentionalMatch.Name;
            MatchImage.Source = PotentionalMatch.ProfileImage;
            CitiesName.ItemsSource = PotentionalMatch.Cities;

            //Changes the labels on the MsgAndBackPopUp
            MatchFoundImage.Source = PotentionalMatch.ProfileImage;
            MatchFoundName.Text = PotentionalMatch.Name;
        }
        else
        {
            NoMatches.IsVisible = true;
        }
    }

    private void Yes_Clicked(object sender, EventArgs e)
    {
        //Adds a match to the users.
        CurrentMatch = new Model.Match(new User[] { Auth.getUser(), PotentionalMatch }, new List<Message>());
        Auth.getUser().Matches.Add(CurrentMatch);
        PotentionalMatch.Matches.Add(CurrentMatch);

        //Enables the matched pop-up
        MsgAndBackPopUp.IsVisible = true;
    }

    private void No_Clicked(object sender, EventArgs e)
    {
        NextUser();
        InitializeComponent();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MsgAndBackPopUp.IsVisible = false;
        NextUser();
        InitializeComponent();
    }

    private void Message_Clicked(object sender, EventArgs e)
    {
      Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(CurrentMatch));
    }
}