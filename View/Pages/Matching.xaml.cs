namespace View.Pages;
using Model;
using Controller;
using System.Linq;

public partial class Matching : ContentPage
{
    readonly static User user = Auth.getUser();

    //Dit wordt straks gekoppeld aan de lijst met potentiele matches die uit het algoritme komen (Input filter).
    public List<User> Users => dummydb.Users;

    //Een lijst met potentiele matches die zijn gefilterd op plaats/dorp.
    public List<User> FilterPlace { get; set; } = new List<User>();

    //De uiteindelijke lijst potentiele matches die zijn gefilterd op plaats/dorp en leeftijd (Output filter).
    public List<User> FilteredPotentionalMatches => FilterPlace.Where(x => x.Age >= user.MinimalAge).Where(x => x.Age <= user.MaximalAge).ToList();

    public Matching()
    {
        InitializeComponent();
        FilterCitys();
        BindingContext = this;
    }

    /// <summary>
    /// Filters potential matches that have selected the same citys
    /// </summary>
    public void FilterCitys()
    {
        foreach (User userMatch in Users)
        {
            foreach (City city in userMatch.Cities)
            {
                foreach (City cityMe in user.Cities)
                {
                    if (city.Name.Equals(cityMe.Name) && !FilterPlace.Contains(userMatch))
                    {
                        FilterPlace.Add(userMatch);
                    }
                }
            }
        }
    }
}