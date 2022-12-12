using Model;
using Controller;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public static User user = Auth.getUser();
    public List<Drink> AllDrinks => dummydb.Drinks;
    public List<Drink> AllFavoriteDrinks => user.GetFavourites();
    public List<Drink> AllLikes => user.GetLikes();
    public List<Drink> AllDislikes => user.GetDislikes();

    public MyDrinks()
    {
        user.AddToFavourites(dummydb.Drinks[0]);
        user.AddToFavourites(dummydb.Drinks[3]);
        user.AddToFavourites(dummydb.Drinks[2]);
        user.AddToLikes(dummydb.Drinks[6]);
        user.AddToLikes(dummydb.Drinks[8]);
        user.AddToLikes(dummydb.Drinks[4]);
        user.AddToDislikes(dummydb.Drinks[1]);
        user.AddToDislikes(dummydb.Drinks[5]);

        InitializeComponent();
        BindingContext = this;
        
    }

    /// <summary>
    /// When clicked on favorite the selected drink gets added to the favorite list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonFavoriteClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetFavourites())) {
            button.IsChecked = false;
        }
        user.AddToFavourites(drink);
    }

    /// <summary>
    /// When clicked on like the selected drink gets added to the like list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonLikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetLikes()))
        {
            button.IsChecked = false;
        }
        user.AddToLikes(drink);
    }

    /// <summary>
    /// When clicked on dislike the selected drink gets added to the dislike list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonDislikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetDislikes()))
        {
            button.IsChecked = false;
        }
        user.AddToDislikes(drink);
    }
}