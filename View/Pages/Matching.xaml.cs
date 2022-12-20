namespace View.Pages;
using Model;
using Controller;

public partial class Matching : ContentPage
{
    User user = Auth.getUser();

    public List<User> Users => dummydb.Users;
    public List<User> FilterAge => Users.Where(x => x.Age > user.MinimalAge).Where(x =>x.Age < user.MaximalAge).ToList();
    public List<User> FilterPlace => Users.Where(user.Cities.ForEach(n => Users.Where(x=> x.Cities.Contains(n))).ToList();

    public Matching()
    {
        InitializeComponent();
        BindingContext = this;
    }
}