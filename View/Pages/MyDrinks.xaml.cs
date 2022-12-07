using Model;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public List<Drink> AllDrinks { get; private set; }
    public string Test = "test";

    public MyDrinks()
    {
        AllDrinks = new List<Drink>();
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());
        AllDrinks.Add(Drink.GetDummyDrink());





        InitializeComponent();

        BindingContext = this;
    }

    async void OnButtonFavoriteClicked(object sender, EventArgs args)
    {
        //AllDrinks.Add(Drink.GetDummyDrink());
        Button button = (Button)sender;
        TestLabel.Text = button.Command.ToString();
        InitializeComponent();
    }

    async void OnButtonLikeClicked(object sender, EventArgs args)
    {
        AllDrinks.Add(Drink.GetDummyDrink());
    }

    async void OnButtonDislikeClicked(object sender, EventArgs args)
    {
        AllDrinks.Add(Drink.GetDummyDrink());
    }
}