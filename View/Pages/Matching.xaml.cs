namespace View.Pages;
using Model;
using Controller;
using System.Linq;

public partial class Matching : ContentPage
{
    readonly static User user = Auth.getUser();

    //Dit wordt straks gekoppeld aan de lijst met potentiele matches die uit het algoritme komen (Input filter).
    public List<User> Users => dummydb.Users;

    //De uiteindelijke lijst potentiele matches die zijn gefilterd op plaats/dorp en leeftijd (Output filter).
    public List<User> FilteredPotentionalMatches => Users.Where(
                                                        a => user.Cities.Intersect(a.Cities).Count() > 0)
                                                        .Where(x => x.Age >= user.MinimalAge)
                                                        .Where(x => x.Age <= user.MaximalAge)
                                                        .ToList();
    public Matching()
    {
        InitializeComponent();
        BindingContext = this;
    }
}