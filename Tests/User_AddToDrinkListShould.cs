using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
	public class User_AddToDrinkListShould
	{
        [Theory]

        [InlineData(true)]

        public void AddToDrinkListFavourites(bool expected)
        {
            User jaap = User.GetDummyUser();
            bool result = jaap.AddToFavourites(new Drink());

            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true)]

        public void AddToDrinkListLikes(bool expected)
        {
            User jaap = User.GetDummyUser();
            bool result = jaap.AddToLikes(new Drink());

            Assert.Equal(expected, result);
        }

        [Theory]

        [InlineData(true)]

        public void AddToDrinkListDislikes(bool expected)
        {
            User jaap = User.GetDummyUser();
            bool result = jaap.AddToDislikes(new Drink());

            Assert.Equal(expected, result);
        }

    }
}

