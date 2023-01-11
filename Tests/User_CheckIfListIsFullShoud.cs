using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests

{
    public class User_CheckIfListIsFullShoud
    {

        [Theory]

        [InlineData(true, 0)]
        [InlineData(true, 2)]
        [InlineData(false, 3)]

        public void CheckIfFavouritesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 0; i < amount; i++)
            {
                jaap.AddToFavourites(Drink.GetDummyDrink(i));
            }

            bool result = jaap.AddToFavourites(Drink.GetDummyDrink(10));


            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true, 0)]
        [InlineData(true, 4)]
        [InlineData(false, 5)]

        public void CheckIfLikesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 0; i < amount; i++)
            {
                jaap.AddToLikes(Drink.GetDummyDrink(i));
            }

            bool result = jaap.AddToLikes(Drink.GetDummyDrink(10));


            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true, 0)]
        [InlineData(true, 2)]
        [InlineData(false, 3)]

        public void CheckIfDislikesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 0; i < amount; i++)
            {
                jaap.AddToDislikes(Drink.GetDummyDrink(i));
            }

            bool result = jaap.AddToDislikes(Drink.GetDummyDrink(10));


            Assert.Equal(expected, result);
        }

    }
}

