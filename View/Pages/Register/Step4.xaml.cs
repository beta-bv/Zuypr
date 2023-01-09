using Model;
using Controller;
namespace View.Pages.Register;

public partial class Step4 : ContentPage
{
    private static readonly User User = Step1.User;
    public List<Drink> AllDrinks => DrinksDatabaseOperations.GetAllDrinksFromDatabase().Except(User.Likes).Except(User.Favourites).ToList();

    private List<Drink> Favourites = User.Favourites;
    private List<Drink> Likes = User.Likes;
    private List<Drink> Dislikes = User.Dislikes;

    static int AmountFavorite;
    static int AmountLikes;
    static int AmountDislikes;

    public Step4()
    {
        AmountFavorite = Favourites.Count;
        AmountLikes = Likes.Count;
        AmountDislikes = Dislikes.Count;

        InitializeComponent();
        BindingContext = this;
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
            if (!button.IsChecked)
            {
                User.RemoveFromDrinkList(drinkDislike);
            }
            else
            {
                if (User.CheckIfListIsFull(User.Dislikes))
                {
                    button.IsChecked = false;
                }
                else if (User.CheckIfInList(drinkLike, User.Likes) || User.CheckIfInList(drinkFave, User.Favourites))
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

    /// <summary>
    /// Goes to the nextpage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Next(object sender, EventArgs e)
    {
        if (User.Dislikes.Count != 0)
        {
            await Navigation.PushAsync(new Step5());
        }
        else
        {
            ErrorFrameL.IsVisible = true;
            ErrorLabelL.Text = "You need to select at least one drink";
        }
    }

    /// <summary>
    /// Goes a page back
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Back(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step3());
    }
}