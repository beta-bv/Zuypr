namespace View.Pages;
using Model;
using Controller;
using System.Linq;

public partial class Matching : ContentPage
{
    public static List<User> PotentionalMatches => Filter.FilteredPotentionalMatches;

    public Matching()
    {
        InitializeComponent();
        BindingContext = this;
    }
}