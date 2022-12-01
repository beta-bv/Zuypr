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
        [InlineData(false, 2)]

        public void CheckIfInFavourites(bool expected, int amount)
        {

            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToFavourites(drink);
            }


            Assert.Equal(expected, jaap.AddToFavourites(drink));
        }

        [Theory]

        [InlineData(true, 1)]
        [InlineData(false, 2)]

        public void CheckIfInLikes(bool expected, int amount)
        {

            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToLikes(drink);
            }


            Assert.Equal(expected, jaap.AddToLikes(drink));
        }

        [Theory]

        [InlineData(true, 1)]
        [InlineData(false, 2)]

        public void CheckIfInDislikes(bool expected, int amount)
        {

            User jaap = User.GetDummyUser();
            Drink drink = Drink.GetDummyDrink();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToDislikes(drink);
            }


            Assert.Equal(expected, jaap.AddToDislikes(drink));
        }
    }
}

