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

        InitializeComponent();

        foreach (Drink d in AllDrinks)
        {
            StackLayout stack = new StackLayout { HeightRequest = 480 };

            flexLayout.Children.Add(stack);

            stack.Children.Add(new Image
            {
                Source = d.ImageUrl,
                HeightRequest = 300,
                WidthRequest = 310
            }); 

            stack.Children.Add(new Label
            {
                Text = d.Name,
                TextColor = Colors.Black,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            });

            Grid grid = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition{ Width = 100},
                new ColumnDefinition{ Width = 100},
                new ColumnDefinition{ Width = 100}
            }
            };

            stack.Children.Add(grid);

            grid.Add(new Button
            {
                Text = "Favourite",
                TextColor = Colors.Black,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            }, 0);

            grid.Add(new Button
            {
                Text = "Like",
                TextColor = Colors.Black,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            }, 1);

            grid.Add(new Button
            {
                Text = "Dislike",
                TextColor = Colors.Black,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            }, 2);
        }
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
        user.AddToDislikes(drink);
    }
}