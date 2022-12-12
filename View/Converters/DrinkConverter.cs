using Model;
using Controller;
using View.Pages;
using System;
using System.Globalization;

namespace View.Converters
{
    public class DrinkConverter : IValueConverter
    {
        private User user = Auth.getUser();
        //public static string[] Favorites => Auth.getUser().GetFavourites().Select(x => x.Name).ToArray();
        //public static string[] Likes => Auth.getUser().GetLikes().Select(x => x.Name).ToArray();
        //public static string[] Dislikes => Auth.getUser().GetDislikes().Select(x => x.Name).ToArray();

        public List<Drink> AllFavoriteDrinks => user.GetFavourites();
        public List<Drink> AllLikes => user.GetLikes();
        public List<Drink> AllDislikes => user.GetDislikes();


        /// <summary>
        /// Checks if a drink is already selected for favorite, like or dislike. If that is the case then it sends back true wich means it will show selected on the screen.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string drinkName = (string)value;
            //Drink drink = dummydb.Drinks.Where(x => )

            //Console.WriteLine(drinkName);

            //Console.WriteLine(Favorites.Contains(drinkName));
            //Console.WriteLine(Likes.Contains(drinkName));
            //Console.WriteLine(Dislikes.Contains(drinkName));

            List<Drink> favorite = AllFavoriteDrinks.Where(x => x.Name.Equals(drinkName)).ToList();
            List<Drink> liked = AllLikes.Where(x => x.Name.Equals(drinkName)).ToList();
            List<Drink> disliked = AllDislikes.Where(x => x.Name.Equals(drinkName)).ToList();

            //switch (Int32.Parse((string)parameter))
            //{
            //    case 0:
            //        Console.WriteLine($"{drinkName} {Favorites.Contains(drinkName)}");
            //        return Favorites.Contains(drinkName) ? true : drinkName;
            //    case 1:
            //        Console.WriteLine($"{drinkName} {Likes.Contains(drinkName)}");
            //        return Likes.Contains(drinkName) ? true : drinkName;
            //    case 2:
            //        Console.WriteLine($"{drinkName} {Dislikes.Contains(drinkName)}");
            //        return Dislikes.Contains(drinkName) ? true : drinkName;
            //    default:
            //        return false;
            //}

            if (favorite.Count() == 1)
            {
                if (Int32.Parse((string)parameter) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (liked.Count() == 1)
            {
                if (Int32.Parse((string)parameter) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (disliked.Count() == 1)
            {
                if (Int32.Parse((string)parameter) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }





        /// <summary>
        /// Interface forces this method to be in it. Isn't used in this solution.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

