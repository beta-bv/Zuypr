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
        [InlineData(true, 3)]
        [InlineData(false, 4)]

        public void CheckIfFavouritesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToFavourites(new Drink());  
            }

            bool result = jaap.AddToFavourites(new Drink());


            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true, 0)]
        [InlineData(true, 5)]
        [InlineData(false, 6)]

        public void CheckIfLikesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToLikes(new Drink());
            }

            bool result = jaap.AddToLikes(new Drink());


            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true, 0)]
        [InlineData(true, 3)]
        [InlineData(false, 4)]

        public void CheckIfDislikesIsFull(bool expected, int amount)
        {
            User jaap = User.GetDummyUser();

            for (int i = 1; i < amount; i++)
            {
                jaap.AddToDislikes(new Drink());
            }

            bool result = jaap.AddToDislikes(new Drink());


            Assert.Equal(expected, result);
        }

    }
}

