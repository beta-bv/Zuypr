using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class User_IsDateOfBirthValidShould
    {
        public class User_CheckAgeShould
        {
            [Theory]
            [InlineData(2010, 1, 1, true)]
            [InlineData(1999, 1, 1, true)]
            [InlineData(2023, 11, 30, false)]
            [InlineData(2150, 12, 1, false)]
            [InlineData(0, 1, 1, false)]
            [InlineData(0, 0, 0, false)]
            [InlineData(-2000, 1, 1, false)]
            public void CheckDateOfBirthValid(int year, int month, int day, bool Expected)
            {
                try
                {
                    DateTime date = new DateTime(year, month, day);
                    Assert.Equal(Expected, User.IsDateOfBirthValid(date));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Assert.Equal(Expected, false);
                }
            }
        }
    }
}
