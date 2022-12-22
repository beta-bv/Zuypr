using Model;
using Controller;
using System.Text.RegularExpressions;
//using static Java.Util.Jar.Attributes;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public User Match { get; set; }
    public List<Drink> Drinks { get; set; }
    public List<User> Users { get; set; }
    public List<Message> messages { get; set; } 
    public User[] MatchUsers { get; set; } = new User[2];
    public bool YesBool = false;
    public Matching()
    {
        InitializeComponent();
        Users = dummydb.Users;
        Users.Insert(0, Auth.getUser());
        NextUser(Users);
    }

    public Matching(List<User> users) {
        Users = users;
        Match = Users[0];
        Drinks = Match.GetFavourites();
        InitializeComponent();
        if (Users is null || Users.Count() == 0)
        {
            NoMatches.IsVisible = true;
        }
        if (Drinks.Count < 2)
        {
            favorite.Text = "Favourite beverage:";
        }
        BindingContext = this;
    }

    private void NextUser(List<User> users) {
        users.RemoveAt(0);
        Application.Current.MainPage = new Matching(users);
        Users = users;
        Match = users[0];
        Drinks = Match.GetFavourites();
        Thread.Sleep(100);
        if (Drinks.Count < 2)
        {
            favorite.Text = "Favorite beverage:";
        }
        //if (YesBool) {
        //    MsgAndBackPopUp.IsVisible = true;
        //}
        if (Users is null || Users.Count() == 1)
        {
            NoMatches.IsVisible = true;
        }
        YesBool = false;
        BindingContext = this;
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
            Model.Match NewMatch = new Model.Match(new User[] { Auth.getUser(), Match }, new List<Message>());
            Auth.getUser().Matches.Add(NewMatch);
            Match.Matches.Add(NewMatch);
            MsgAndBackPopUp.IsVisible = true;
            //Array.Clear(MatchUsers, 0, MatchUsers.Length);
            // Set Database Match and Chat
            if (Users is null || Users.Count() == 1)
            {
                NoMatches.IsVisible = true;
            }
            else
            {
                YesBool = true;
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

        // Show next person
        // Update List
    }
    private void Back_Clicked(object sender, EventArgs e){
        MsgAndBackPopUp.IsVisible = false;
        NextUser(Users);
    }
    private void Message_Clicked(object sender, EventArgs e) {
        foreach (Model.Match match in Controller.Auth.getUser().Matches)
        {
            foreach (User user in match.Users)
            {
                if (user == Match)
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