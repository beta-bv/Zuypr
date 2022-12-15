using Model;
using Controller;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    private static readonly User User = Auth.getUser();
    public List<Drink> AllDrinks => dummydb.Drinks;

    private List<Drink> Favourites = User.GetFavourites();
    private List<Drink> Likes = User.GetLikes();
    private List<Drink> Dislikes = User.GetDislikes();

    static int AmountFavorite;
    static int AmountLikes;
    static int AmountDislikes;

    public MyDrinks()
    {
        AmountFavorite = Favourites.Count;
        AmountLikes = Likes.Count;
        AmountDislikes = Dislikes.Count;

        InitializeComponent();
        BindingContext = this;
    }

    /// <summary>
    /// When clicked on favorite the selected drink gets added to the favorite list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void OnFavouriteOptionChanged(object sender, EventArgs args)
    {
        CheckBox button = (CheckBox)sender;
        Drink drink = (Drink)button.BindingContext;
        drink = Favourites.FirstOrDefault(x => x.Name == drink.Name);

        if (AmountFavorite == 0)
        {
            if (button.IsChecked == false)
            {
                User.RemoveFromDrinkList(drink);
            }
            else if (button.IsChecked == true) {
                if (User.CheckIfListIsFull(User.GetFavourites()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToFavourites(drink);
                }
            }
            //else
            //{
            //    if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetFavourites()))
            //    {
            //        //button.IsChecked = false;
            //    }
            //    else
            //    {
            //        User.AddToFavourites(drink);
            //    }
            //}
        }
        else
            {
                AmountFavorite--;
            }
        }

    /// <summary>
    /// When clicked on like the selected drink gets added to the like list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void OnLikeOptionChanged(object sender, EventArgs args)
    {
        CheckBox button = (CheckBox)sender;
        Drink drink = (Drink)button.BindingContext;
        if (AmountLikes == 0)
        {
            if (button.IsChecked == false)
            {
                User.RemoveFromDrinkList(drink);
            }
            else
            {
                if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetLikes()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToLikes(drink);
                    button.IsChecked = true;
                }
            }
        }
        else
        {
            AmountLikes--;
        }
    }

    /// <summary>
    /// When clicked on dislike the selected drink gets added to the dislike list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void OnDislikeOptionChanged(object sender, EventArgs args)
    {
        CheckBox button = (CheckBox)sender;
        Drink drink = (Drink)button.BindingContext;
        if (AmountDislikes == 0)
        {
            if (button.IsChecked == false)
            {
                if (User.RemoveFromDrinkList(drink))
                {
                    string verwijderd = "ja";
                }
                else
                {
                    string verwijderd = "nee";
                }
            }
            else
            {
                if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetDislikes()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToDislikes(drink);
                    button.IsChecked = true;
                }
            }
        }
        else
        {
            AmountDislikes--;
        }
    }
}