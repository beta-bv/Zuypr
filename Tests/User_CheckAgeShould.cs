using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_CheckAgeShould
    {
        [Theory]
        [InlineData(2010, 1, 1, false)] 
        [InlineData(1999, 1, 1, true)]
        [InlineData(2010, 11, 30, true)]
        [InlineData(2004, 12, 30, false)]
        public void CheckAge(int year, int month, int day, bool Expected)
        {
            DateTime date = new DateTime(year, month, day);
            Assert.Equal(Expected, User.CheckAge(date));
        }
    }
}
