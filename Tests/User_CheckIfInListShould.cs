using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_CheckIfInListShould
    {

        [Theory]

        [InlineData(true, 1)]
        [InlineData(false, 3)]

        public void CheckIfInFavourites(bool expected, int drinkIndex)
        {
            User jaap = User.GetDummyUser();
            jaap.AddToFavourites(Drink.GetDummyDrink(0));
            jaap.AddToFavourites(Drink.GetDummyDrink(1));
            jaap.AddToFavourites(Drink.GetDummyDrink(2));

            Drink drinkToCheck = Drink.GetDummyDrink(drinkIndex);

            Assert.Equal(expected, jaap.CheckIfInList(drinkToCheck, jaap.Favourites));
        }

        [Theory]

        [InlineData(true, 1)]
        [InlineData(false, 3)]

        public void CheckIfInLikes(bool expected, int drinkIndex)
        {
            User jaap = User.GetDummyUser();
            jaap.AddToLikes(Drink.GetDummyDrink(0));
            jaap.AddToLikes(Drink.GetDummyDrink(1));
            jaap.AddToLikes(Drink.GetDummyDrink(2));

            Drink drinkToCheck = Drink.GetDummyDrink(drinkIndex);

            Assert.Equal(expected, jaap.CheckIfInList(drinkToCheck, jaap.Likes));
        }

        [Theory]

        [InlineData(true, 1)]
        [InlineData(false, 3)]

        public void CheckIfInDislikes(bool expected, int drinkIndex)
        {
            User jaap = User.GetDummyUser();
            jaap.AddToDislikes(Drink.GetDummyDrink(0));
            jaap.AddToDislikes(Drink.GetDummyDrink(1));
            jaap.AddToDislikes(Drink.GetDummyDrink(2));

            Drink drinkToCheck = Drink.GetDummyDrink(drinkIndex);

            Assert.Equal(expected, jaap.CheckIfInList(drinkToCheck, jaap.Dislikes));
        }
    }
}

