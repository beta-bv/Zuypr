﻿using Model;
using Controller;
namespace View.Pages.Register;

public partial class Step2 : ContentPage
{
    private static readonly User User = Step1.User;
    public List<Drink> AllDrinks => dummydb.Drinks.Except(User.GetLikes()).Except(User.GetDislikes()).ToList();

    private List<Drink> Favourites = User.GetFavourites();
    private List<Drink> Likes = User.GetLikes();
    private List<Drink> Dislikes = User.GetDislikes();

    static int AmountFavorite;
    static int AmountLikes;
    static int AmountDislikes;

    public Step2()
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
            if (!button.IsChecked)
            {
                User.RemoveFromDrinkList(drinkFave);
            }
            else
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
    /// Goes to the next page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Next(object sender, EventArgs e)
    {
        if (User.GetFavourites().Count != 0) {
            await Navigation.PushAsync(new Step3());
        }
        else {
                ErrorFrameL.IsVisible = true;
                ErrorLabelL.Text = "You need to select at least one drink";
        }
    }
}