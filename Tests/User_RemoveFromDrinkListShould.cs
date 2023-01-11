using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_RemoveFromDrinkListShould
    {

        [Theory]

        [InlineData(false, 0)]
        [InlineData(true, 1)]

        public void RemoveFromDrinkListFavourites(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink(0);

            if (amount == 1)
            {
                jaap.AddToFavourites(drink);
            }

            Assert.Equal(expected, jaap.RemoveFromDrinkList(drink));
        }

        [Theory]

        [InlineData(false, 0)]
        [InlineData(true, 1)]

        public void RemoveFromDrinkListLikes(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink(1);

            if (amount == 1)
            {
                jaap.AddToLikes(drink);
            }

            Assert.Equal(expected, jaap.RemoveFromDrinkList(drink));
        }

        [Theory]

        [InlineData(false, 0)]
        [InlineData(true, 1)]

        public void RemoveFromDrinkListDislikes(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink(2);

            if (amount == 1)
            {
                jaap.AddToDislikes(drink);
            }

            Assert.Equal(expected, jaap.RemoveFromDrinkList(drink));
        }
    }
}

