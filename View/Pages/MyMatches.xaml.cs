using Model;

namespace View.Pages;

public partial class MyMatches : ContentPage
{
    public List<User> AllMatches { get; set; }
    public MyMatches()
    {
        AllMatches = new List<User>
        {
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15)),
            new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15))
        };
        InitializeComponent();
        BindingContext = this;
    }

    private void ProfileImage_OnClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new Profile(new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15))));
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushAsync(new Chat());
    }
}