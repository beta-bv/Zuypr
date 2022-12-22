using Model;
using Controller;
using System.Text.RegularExpressions;
//using static Java.Util.Jar.Attributes;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public User PotentionalMatch { get; set; }
    public List<User> Users = dummydb.Users;

    public List<Drink> Drinks { get; set; }
    public List<Message> messages { get; set; } 
    public User[] MatchUsers { get; set; } = new User[2];
    public bool YesBool = false;

    public Matching()
    {
        PotentionalMatch = Users[0];
        InitializeComponent();
        //if (Users == null || Users.Count() == 1)
        //{
        //    NoMatches.IsVisible = true;
        //}

        //Users.Insert(0, Auth.getUser());
        //NextUser(Users);

        BindingContext = this;
    }

    //public Matching(List<User> users) {
    //    Users = users;
    //    PotentionalMatch = Users[0];
    //    Drinks = PotentionalMatch.GetFavourites();
    //    InitializeComponent();
    //    if (Drinks.Count < 2)
    //    {
    //        favorite.Text = "Favourite beverage:";
    //    }
    //    BindingContext = this;
    //}

    private void NextUser(List<User> users) {
        users.RemoveAt(0);
        Users = users;
        PotentionalMatch = users[0];
        Drinks = PotentionalMatch.GetFavourites();

        if (Drinks.Count < 2)
        {
            favorite.Text = "Favourite beverage:";
        }
        if (YesBool) {
            MsgAndBackPopUp.IsVisible = true;
        }
        if (Users is null || Users.Count() == 1)
        {
            NoMatches.IsVisible = true;
        }

        YesBool = false;
        BindingContext = this;
        //MatchName.SetBinding(Label.TextProperty, nameof(Match.Name));
    }


    private void Yes_Clicked(object sender, EventArgs e)
    {
        //if (MatchAdded())
        //{
            var temp = (Button)sender;
            // Show next person
            // If match show Profile card and chat button
            // Update List
            // Make Match
            Model.Match NewMatch = new Model.Match(new User[] { Auth.getUser(), PotentionalMatch }, new List<Message>());
            Auth.getUser().Matches.Add(NewMatch);
            PotentionalMatch.Matches.Add(NewMatch);
            //Array.Clear(MatchUsers, 0, MatchUsers.Length);
            // Set Database Match and Chat
            if (Users is null || Users.Count() == 1)
            {
                NoMatches.IsVisible = true;
            }
            else
            {
                YesBool = true;
                NextUser(Users);
            }
        // }
    }

    private void No_Clicked(object sender, EventArgs e)
    {
        var temp = (Button)sender;
        if (Users is null || Users.Count() == 1)
        {
            NoMatches.IsVisible= true;
        }
        else
        {
            NextUser(Users);
        }
        InitializeComponent();
        // Show next person
        // Update List
    }

    private void Back_Clicked(object sender, EventArgs e){
        MsgAndBackPopUp.IsVisible = false;
        InitializeComponent();
    }

    private void Message_Clicked(object sender, EventArgs e) {
        MsgAndBackPopUp.IsVisible = false;
        InitializeComponent();
        foreach (Model.Match match in Controller.Auth.getUser().Matches)
        {
            foreach (User user in match.Users)
            {
                if (user == PotentionalMatch)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(match));
                }
            }
        }
    }

    public bool MatchAdded()
    {
        return true;
        //throw new Exception("matchadded is nog niet implemented");
    }
}