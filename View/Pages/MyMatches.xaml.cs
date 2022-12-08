using Model;

namespace View.Pages;

public partial class MyMatches : ContentPage
{
    public List<User> AllMatches { get; set; }
    public MyMatches()
    {
        AllMatches = new List<User>
        {
            new User("Mark", "hoi@gmail.com", "Neeneenee!", new DateTime(2000, 7, 15)),
            new User("Niels", "hoi@gmail.com", "Neeneenee!", new DateTime(2001, 7, 15)),
            new User("Stan", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Siem", "hoi@gmail.com", "Neeneenee!", new DateTime(2003, 7, 15)),
            new User("Dylan", "hoi@gmail.com", "Neeneenee!", new DateTime(1999, 7, 15)),
            new User("Thomas", "hoi@gmail.com", "Neeneenee!", new DateTime(1998, 7, 15)),
            new User("Merijn", "hoi@gmail.com", "Neeneenee!", new DateTime(1997, 7, 15))
        };
        InitializeComponent();
        BindingContext = this;
    }

    private void ProfileImage_OnClicked(object sender, EventArgs e)
    {
        var temp = (ImageButton) sender;
        Application.Current.MainPage.Navigation.PushAsync(new Profile((User)temp.BindingContext));
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        var temp = (ImageButton) sender;
        //Application.Current.MainPage.Navigation.PushAsync(new ChatScreen((User)temp.BindingContext));
        Application.Current.MainPage.Navigation.PushAsync(new ChatScreen());

    }
}