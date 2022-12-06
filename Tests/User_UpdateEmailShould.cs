using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_UpdateEmailShould
    {
        User TestUser;

        public User_UpdateEmailShould()
        {
            TestUser = new User("crong", "gmail@gmail.com", "RAREMAARweee123!", new DateTime(2000, 10, 2));
        }

        [Theory]
        [InlineData("gmail@gmail.com", "gmail@gmail.com", false)]
        [InlineData("gmail@gmail.com", "gmail@.com", true)]
        [InlineData("gmail@gmail.com", "gmail.com", false, true)]
        [InlineData("gmail@gmail.com", "neiwe@gmail.com", true)]
        [InlineData("hotmail@hot.com", "neiwe@gmail.com", false)]
        [InlineData("gmail@gmail.com", "stinky@hotmail.com", true)]
        public void CheckEmailUpdate(string emailOld, string emailNew, bool expected, bool exception = false)
        {
            if (exception)
            {
                Assert.Throws<ArgumentException>(() => TestUser.UpdateUserEmail(emailNew, emailOld));
            }
            else
            {
                Assert.Equal(expected, TestUser.UpdateUserEmail(emailNew, emailOld));
            }
        }
    }
}