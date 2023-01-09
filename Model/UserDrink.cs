using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("user_drinks")]
    [PrimaryKey("Id")]
    public class UserDrink
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("DrinkId")]
        public Drink Drink { get; set; }
        public UserDrinkType Type { get; set; }

        // Exists for EF
        public UserDrink()
        {
        }

        public UserDrink(User user, Drink drink, UserDrinkType type)
        {
            User = user;
            Drink = drink;
            Type = type;
        }
    }

    public enum UserDrinkType
    {
        Dislike,
        Like,
        Favourite
    }
}
