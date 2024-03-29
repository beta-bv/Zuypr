﻿using Model;
using Controller;
namespace View.Pages.Register;

public partial class Step3 : ContentPage
{
    private static readonly User User = Step1.User;
    public List<Drink> AllDrinks => DrinksDatabaseOperations.GetAllDrinksFromDatabase().Except(User.Favourites).Except(User.Dislikes).ToList();

    private List<Drink> Favourites = User.Favourites;
    private List<Drink> Likes = User.Likes;
    private List<Drink> Dislikes = User.Dislikes;

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
            if (!button.IsChecked)
            {
                User.RemoveFromDrinkList(drinkLike);
            }
            else
            {
                if (User.CheckIfListIsFull(User.Likes))
                {
                    button.IsChecked = false;
                }
                else if (User.CheckIfInList(drinkDislike, User.Dislikes) || User.CheckIfInList(drinkFave, User.Favourites))
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
    /// Goes a page back
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Back(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step2());
    }

    /// <summary>
    /// Goes to the next page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Next(object sender, EventArgs e)
    {
        if (User.Likes.Count != 0)
        {
            await Navigation.PushAsync(new Step4());
        }
        else
        {
            ErrorFrameL.IsVisible = true;
            ErrorLabelL.Text = "You need to select at least one drink";
        }
    }
}