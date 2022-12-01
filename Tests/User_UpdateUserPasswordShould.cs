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
            TestUser = new User("crong", "gmail@gmail.com", "123", new DateTime(2000, 10, 2));
        }

        [Theory]
        [InlineData("", false)]
        public void CheckName(string name, bool Expected)
        {
            Assert.Equal(Expected, User.IsNameValid(name));
        }
    }
}
