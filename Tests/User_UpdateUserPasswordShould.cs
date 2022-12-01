using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_UpdateUserPasswordShould
    {
        User TestUser;
        public User_UpdateUserPasswordShould()
        {
            TestUser = new User("crong", "gmail@gmail.com", "KrakendeBanden#", new DateTime(2000, 10, 2));
        }

        [Theory]
        [InlineData("KrakendeBanden#", "123", "123", false)]
        [InlineData("KrakendeBanden#", "123", "12", false)]
        [InlineData("12", "124", "124", false)]
        [InlineData("KrakendeBanden#", "Niw", "", false)]
        [InlineData("", "", "", false)]
        [InlineData("KrakendeBanden#", "VageJonges", "VageJonges", false)]
        [InlineData("KrakendeBanden#", "vageJonges*", "vageJonges*", false)]
        [InlineData("KrakendeBanden#", "VageJonges*", "VageJonges*", true)]
        [InlineData("KrakendeBanden#", "GoedWachtWoordman!", "GoedWachtWoordman!", true)]
        public void CheckName(string passwordOld, string passwordNew1, string passwordNew2, bool Expected)
        {
            Assert.Equal(Expected, TestUser.UpdateUserPassword(passwordOld, passwordNew1, passwordNew2));
        }
    }
}
