using Model;
using View.Pages;
using System;
using System.Globalization;

namespace View.Converters
{
    public class DinkConverter : IValueConverter
    {
        public List<Drink> AllFavoriteDrinks => MyDrinks.user.GetFavourites();
        public List<Drink> AllLikes => MyDrinks.user.GetLikes();
        public List<Drink> AllDislikes => MyDrinks.user.GetDislikes();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string drinkName = (string)value;
            List<Drink> favorite = AllFavoriteDrinks.Where(x => x.DrinkName.Equals(drinkName)).ToList();
            List<Drink> liked = AllLikes.Where(x => x.DrinkName.Equals(drinkName)).ToList();
            List<Drink> disliked = AllDislikes.Where(x => x.DrinkName.Equals(drinkName)).ToList();

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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}

