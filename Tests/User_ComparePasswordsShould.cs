using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_ComparePasswordsShould
    {
            [Theory]
            [InlineData("cringemannetje", "Cringemannetje", false)]
            [InlineData("cringemannetje1233333", "Cringemannetje!!!!!!!!!!!!!!", false)]
            [InlineData("cringemannetje", "cringemannetje", true)]
            [InlineData("Cringemannetjes1!!!;;;", "Cringemannetjes1!!!;;;", true)]
        public void CheckComparePassword(string password1, string password2, bool Expected)
            {
                Assert.Equal(Expected, User.ComparePasswords(password1, password2));
            }
        }
}
