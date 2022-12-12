using Model;
using Controller;
using View.Pages;
using System;
using System.Globalization;

namespace View.Converters
{
    public class DinkConverter : IValueConverter
    {
        public List<Drink> AllFavoriteDrinks => Auth.getUser().GetFavourites();
        public List<Drink> AllLikes => Auth.getUser().GetLikes();
        public List<Drink> AllDislikes => Auth.getUser().GetDislikes();


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
            List<Drink> favorite = AllFavoriteDrinks.Where(x => x.Name.Equals(drinkName)).ToList();
            List<Drink> liked = AllLikes.Where(x => x.Name.Equals(drinkName)).ToList();
            List<Drink> disliked = AllDislikes.Where(x => x.Name.Equals(drinkName)).ToList();

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
            return false;
        }
    }
}

