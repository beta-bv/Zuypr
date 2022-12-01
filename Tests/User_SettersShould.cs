using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;

namespace Tests
{
    public class User_SettersShould
    {
        User TestUser;
        public User_SettersShould()
        {
            TestUser = new User("crong", "gmail@gmail.com", "Great01Password!", new DateTime(2000, 10, 2));
        }

        [Theory]
        [InlineData("cringe", true)]
        [InlineData("......,,,///////\\\\", false)]
        public void CheckName(string name, bool expected)
        {
            if (expected == false)
            {
                Assert.Throws<Exception>(() => TestUser.Name = name);
                return;
            }

            TestUser.Name = name;
            Assert.Equal(name, TestUser.Name);
        }

        [Theory]    
        [InlineData(2010, 1, 1, false)]
        [InlineData(1999, 1, 1, true)]
        public void CheckAge(int year, int month, int day, bool expected)
        {
            DateTime date = new DateTime(year, month, day);

            if (expected == false)
            {
                Assert.Throws<Exception>(() => TestUser.DateOfBirth = date);
                return;
            }
            TestUser.DateOfBirth = date;
            Assert.Equal(date, TestUser.DateOfBirth);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("onlylowercase", false)]
        [InlineData("ONLYUPPERCASE", false)]
        [InlineData("1234567890", false)]
        [InlineData("A!", false)]
        [InlineData("short", false)]

        [InlineData("Goodpassword!", true)]
        [InlineData("Pass123!", true)]
        [InlineData("This is quite a long password with spaces!", true)]
        public void CheckPassword(string password, bool expected)
        {
            if (expected == false)
            {
                Assert.Throws<Exception>(() => TestUser.Password = password);
                return;
            }
            TestUser.Password = password;
            Assert.Equal(User.HashString(password), TestUser.Password);
        }

        [Theory]
        [InlineData("cringe", false)]
        [InlineData("example@gmail.com", true)]
        public void CheckEmail(string email, bool expected)
        {
            if (expected == false)
            {
                Assert.Throws<Exception>(() => TestUser.Email = email);
                return;
            }
            TestUser.Email = email;
            Assert.Equal(email, TestUser.Email);
        }

    }
}
