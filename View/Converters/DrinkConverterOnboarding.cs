using Controller;
using View.Pages.Register;
using Model;
using System.Globalization;

namespace View.Converters
{
    public class DrinkConverterOnboarding : IValueConverter
    {
        public static User user = Step1.User;
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
            string[] favorite = user.Favourites.Select(x => x.Name).ToArray();
            string[] liked = user.Likes.Select(x => x.Name).ToArray();
            string[] disliked = user.Dislikes.Select(x => x.Name).ToArray();

            if (!drinkName.Equals("False"))
            {
                return Int32.Parse((string)parameter) switch
                {
                    0 => favorite.Contains(drinkName),
                    1 => liked.Contains(drinkName),
                    2 => disliked.Contains(drinkName),
                    _ => (object)false,
                };
            }
            return (object)false;
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
            return parameter;
        }
    }
}