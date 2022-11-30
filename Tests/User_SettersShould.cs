using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_SettersShould
    {
        public User_SettersShould()
        {
            User TestUser = new User("crong", "gmail@gmail.com", new DateTime(2000, 10, 2));
        }

        [Theory]
        [InlineData("cringe", true)]
        [InlineData("......,,,///////\\\\", false)]
        public void CheckName(string name, bool Expected)
        {
            Assert.Equal(Expected, TestUser.Name = name);
        }
        [Theory]
        [InlineData(2010, 1, 1, false)]
        [InlineData(1999, 1, 1, true)]
        public void CheckAge(int year, int month, int day, bool Expected)
        {
            DateTime date = new DateTime(year, month, day);
            Assert.Equal(Expected, User.DateOfBirth = date);
        }
        [Theory]
        [InlineData("cringe", false)]
        [InlineData("example@gmail.com", true)]
        public void CheckEmail(string name, bool Expected)
        {
            Assert.Equal(Expected, User.Email = name);
        }

    }
}
