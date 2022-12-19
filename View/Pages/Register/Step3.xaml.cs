using Model;
using Controller;
namespace View.Pages.Register;


public partial class Step3 : ContentPage
{
    // int count = 0;

    private static readonly User User = Step1.User;
    public List<Drink> AllDrinks => dummydb.Drinks;

    private List<Drink> Favourites = User.GetFavourites();
    private List<Drink> Likes = User.GetLikes();
    private List<Drink> Dislikes = User.GetDislikes();

    static int AmountFavorite;
    static int AmountLikes;
    static int AmountDislikes;

    public Step3()
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
        Drink drinkAdd = (Drink)button.BindingContext;
        Drink drinkFave = Favourites.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkLike = Likes.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkDislike = Dislikes.FirstOrDefault(x => x.Name == drinkAdd.Name);

        if (AmountFavorite == 0)
        {
            if (button.IsChecked == false)
            {
                User.RemoveFromDrinkList(drinkFave);
            }
            else if (button.IsChecked == true)
            {
                if (User.CheckIfListIsFull(User.GetFavourites()))
                {
                    button.IsChecked = false;
                }
                else if (User.CheckIfInList(drinkDislike, User.GetDislikes()) || User.CheckIfInList(drinkLike, User.GetLikes()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToFavourites(drinkAdd);
                }
            }
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
        Drink drinkAdd = (Drink)button.BindingContext;
        Drink drinkFave = Favourites.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkLike = Likes.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkDislike = Dislikes.FirstOrDefault(x => x.Name == drinkAdd.Name);

        if (AmountLikes == 0)
        {
            if (button.IsChecked == false)
            {
                User.RemoveFromDrinkList(drinkLike);
            }
            else if (button.IsChecked == true)
            {
                if (User.CheckIfListIsFull(User.GetLikes()))
                {
                    button.IsChecked = false;
                }
                else if (User.CheckIfInList(drinkDislike, User.GetDislikes()) || User.CheckIfInList(drinkFave, User.GetFavourites()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToLikes(drinkAdd);
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
        Drink drinkAdd = (Drink)button.BindingContext;
        Drink drinkFave = Favourites.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkLike = Likes.FirstOrDefault(x => x.Name == drinkAdd.Name);
        Drink drinkDislike = Dislikes.FirstOrDefault(x => x.Name == drinkAdd.Name);

        if (AmountDislikes == 0)
        {
            if (button.IsChecked == false)
            {
                User.RemoveFromDrinkList(drinkDislike);
            }
            else if (button.IsChecked == true)
            {
                if (User.CheckIfListIsFull(User.GetDislikes()))
                {
                    button.IsChecked = false;
                }
                else if (User.CheckIfInList(drinkLike, User.GetLikes()) || User.CheckIfInList(drinkFave, User.GetFavourites()))
                {
                    button.IsChecked = false;
                }
                else
                {
                    User.AddToDislikes(drinkAdd);
                }
            }
        }
        else
        {
            AmountDislikes--;
        }
    }


    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step4());
    }
}