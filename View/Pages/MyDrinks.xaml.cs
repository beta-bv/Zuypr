using Model;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public List<Drink> AllDrinks { get; private set; }
    public List<Drink> AllFavoriteDrinks => user.GetFavourites();
    public List<Drink> AllLikes => user.GetLikes();
    public List<Drink> AllDislikes => user.GetDislikes();

    public string Test = "test";
    public static User user { get; set; }

    public MyDrinks()
    {
        user = User.GetDummyUser();
        AllDrinks = new List<Drink>();
        Drink beer = new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Beer", 10);
        Drink wine = new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Wine", 10);
        Drink fristi = new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Fristi", 10);
        Drink cola = new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Cola", 10);
        Drink appelsap = new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Appelsap", 10);

        AllDrinks.Add(beer);
        AllDrinks.Add(wine);
        AllDrinks.Add(fristi);
        AllDrinks.Add(cola);
        AllDrinks.Add(appelsap);

        user.AddToFavourites(beer);
        user.AddToFavourites(appelsap);
        user.AddToDislikes(wine);
        user.AddToLikes(fristi);

        InitializeComponent();

        BindingContext = this;
    }

    async void OnButtonFavoriteClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        user.AddToFavourites(drink);
    }

    async void OnButtonLikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        user.AddToLikes(drink);
    }

    async void OnButtonDislikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        Drink drink = (Drink)button.BindingContext;
        user.AddToDislikes(drink);
    }
}