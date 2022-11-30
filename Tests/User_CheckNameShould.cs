using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_IsNameValidShould
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("Siem", true)]
        [InlineData("Siem Gerritsen", true)]
        [InlineData("meer dan 50 karakters aaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]
        [InlineData("deze zin is preceis vijfitg karakters lang aaaaaaa", true)]
        [InlineData("@", false)]
        [InlineData("!", false)]
        [InlineData("Hänß", true)]
        public void CheckName(string name, bool Expected)
        {
            Assert.Equal(Expected, User.IsNameValid(name));
        }
    }
}
