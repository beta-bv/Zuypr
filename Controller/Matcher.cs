using System;
using Model;

namespace Controller
{
    public class Matcher
    {
        private readonly User User;
        private readonly string[] MyFavouriteDrinks;
        private readonly string[] MyLikedDrinks;
        private readonly string[] MyDislikedDrinks;
        private readonly DrinkType[] MyFavouriteTypes;
        private readonly DrinkType[] MyLikedTypes;
        private readonly DrinkType[] MyDislikedTypes;

        public List<User> UserList;
        public List<User> MatchList = new List<User>();

        public double PassingScore { get; private set; }

        public double ExactMatchInfluence { get; private set; }
        public double TypeMatchInfluence { get; private set; }

        public double PositiveMatchScore { get; private set; }
        public double NegativeMatchScore { get; private set; }
        public double SemiPositiveMatchScore { get; private set; }
        public double SemiNegativeMatchScore { get; private set; }

        /// <summary>
        /// FOR TESTING ONLY
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passingScore">Score needed for a user to be added to the MatchList</param>
        /// <param name="exactMatchInfluence">How much impact exact matches have on the final score, type matches are based on this value</param>
        public Matcher(double passingScore = 0.15, double exactMatchInfluence = 0.6)
        {
            try
            {
                User = Auth.getUser();
            }
            catch
            {
                throw new Exception("No user!");
            }

            UserList = dummydb.Users.Where(u => u.Name != User.Name).ToList();

            MyFavouriteDrinks = User.GetFavourites().Select(d => d.Name).ToArray();
            MyLikedDrinks = User.GetLikes().Select(d => d.Name).ToArray();
            MyDislikedDrinks = User.GetDislikes().Select(d => d.Name).ToArray();

            MyFavouriteTypes = User.GetFavourites().Select(d => d.Type).ToArray();
            MyLikedTypes = User.GetLikes().Select(d => d.Type).ToArray();
            MyDislikedTypes = User.GetDislikes().Select(d => d.Type).ToArray();

            PassingScore = passingScore;

            ExactMatchInfluence = exactMatchInfluence;
            TypeMatchInfluence = 1.0 - exactMatchInfluence;

            PositiveMatchScore = 4.0;
            NegativeMatchScore = -2.0;
            SemiPositiveMatchScore = 1.5;
            SemiNegativeMatchScore = -1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passingScore">Score needed for a user to be added to the MatchList</param>
        /// <param name="exactMatchInfluence">How much impact exact matches have on the final score, type matches are based on this value</param>
        /// <param name="positiveMatchScore"></param>
        /// <param name="negativeMatchScore"></param>
        /// <param name="semiPositiveMatchScore"></param>
        /// <param name="semiNegativeMatchScore"></param>
        /// <exception cref="Exception"></exception>
        public Matcher(double passingScore, double exactMatchInfluence, double positiveMatchScore, double negativeMatchScore, double semiPositiveMatchScore, double semiNegativeMatchScore)
        {
            try
            {
                User = Auth.getUser();
            }
            catch
            {
                throw new Exception("No user!");
            }

            UserList = dummydb.Users.Where(u => u.Name != User.Name).ToList();

            MyFavouriteDrinks = User.GetFavourites().Select(d => d.Name).ToArray();
            MyLikedDrinks = User.GetLikes().Select(d => d.Name).ToArray();
            MyDislikedDrinks = User.GetDislikes().Select(d => d.Name).ToArray();

            MyFavouriteTypes = User.GetFavourites().Select(d => d.Type).ToArray();
            MyLikedTypes = User.GetLikes().Select(d => d.Type).ToArray();
            MyDislikedTypes = User.GetDislikes().Select(d => d.Type).ToArray();

            PassingScore = passingScore;

            ExactMatchInfluence = exactMatchInfluence;
            TypeMatchInfluence = 1.0 - exactMatchInfluence;

            PositiveMatchScore = positiveMatchScore;
            NegativeMatchScore = negativeMatchScore;
            SemiPositiveMatchScore = semiPositiveMatchScore;
            SemiNegativeMatchScore = semiNegativeMatchScore;
        }

        public List<User> GeneratePotentialMatches()
        {
            foreach (User user in UserList)
            {
                // HACK: Holy fuck this is broken
                double exactMatchScore = this.GetExactMatchScore(user);
                double typeMatchScore = this.GetTypeMatchScore(user);

                double score = exactMatchScore * ExactMatchInfluence + typeMatchScore * TypeMatchInfluence;

                if (score >= PassingScore)
                {
                    MatchList.Add(user);
                }
            }
            return MatchList;
        }

        /// <summary>
        /// Checks how allike the logged in user is to the provided user. Checking the Exact matches
        /// </summary>
        /// <param name="potentialMatch">The user to match against</param>
        /// <returns>Returns the earned points</returns>
        private double GetExactMatchScore(User potentialMatch)
        {
            string[] theirFavouriteDrinks = potentialMatch.GetFavourites().Select(d => d.Name).ToArray();
            string[] theirLikedDrinks = potentialMatch.GetLikes().Select(d => d.Name).ToArray();
            string[] theirDislikedDrinks = potentialMatch.GetDislikes().Select(d => d.Name).ToArray();
            double score = 0;

            // Grabbing the lowest array count to make matching more fair
            int lowest_f_type = Math.Min(MyFavouriteDrinks.Length, theirFavouriteDrinks.Length);
            int lowest_l_type = Math.Min(MyLikedDrinks.Length, theirLikedDrinks.Length);
            int lowest_d_type = Math.Min(MyDislikedDrinks.Length, theirDislikedDrinks.Length);
            double possible_score = lowest_f_type * PositiveMatchScore +
                                    lowest_l_type * PositiveMatchScore +
                                    lowest_d_type * SemiPositiveMatchScore;

            // Get All drink match counts
            double f_f_matches = GetMatches(MyFavouriteDrinks, theirFavouriteDrinks) * PositiveMatchScore;
            double f_l_matches = GetMatches(MyFavouriteDrinks, theirLikedDrinks) * SemiPositiveMatchScore;
            double f_d_matches = GetMatches(MyFavouriteDrinks, theirDislikedDrinks) * NegativeMatchScore;
            double f_score = f_f_matches + f_l_matches + f_d_matches;

            double l_f_matches = GetMatches(MyLikedDrinks, theirFavouriteDrinks) * SemiPositiveMatchScore;
            double l_l_matches = GetMatches(MyLikedDrinks, theirLikedDrinks) * PositiveMatchScore;
            double l_d_matches = GetMatches(MyLikedDrinks, theirDislikedDrinks) * SemiNegativeMatchScore;
            double l_score = l_f_matches + l_l_matches + l_d_matches;

            double d_f_matches = GetMatches(MyDislikedDrinks, theirFavouriteDrinks) * NegativeMatchScore;
            double d_l_matches = GetMatches(MyDislikedDrinks, theirLikedDrinks) * SemiNegativeMatchScore;
            double d_d_matches = GetMatches(MyDislikedDrinks, theirDislikedDrinks) * SemiPositiveMatchScore;
            double d_score = d_f_matches + d_l_matches + d_d_matches;

            //Console.WriteLine($"{f_f_matches,3}, {f_l_matches,3}, {f_d_matches,3} = {f_score}");
            //Console.WriteLine($"{l_f_matches,3}, {l_l_matches,3}, {l_d_matches,3} = {l_score}");
            //Console.WriteLine($"{d_f_matches,3}, {d_l_matches,3}, {d_d_matches,3} = {d_score}");

            score += f_score + l_score + d_score;
            return score < 0 ? 0 : 1 / possible_score * score;
        }

        /// <summary>
        /// Checks how allike the logged in user is to the provided user. Checking the DrinkType matches
        /// </summary>
        /// <param name="potentialMatch">The user to match against</param>
        /// <returns>Returns the earned points</returns>
        private double GetTypeMatchScore(User potentialMatch)
        {
            DrinkType[] theirFavouriteTypes = potentialMatch.GetFavourites().Select(d => d.Type).ToArray();
            DrinkType[] theirLikedTypes = potentialMatch.GetLikes().Select(d => d.Type).ToArray();
            DrinkType[] theirDislikedTypes = potentialMatch.GetDislikes().Select(d => d.Type).ToArray();
            double score = 0;

            // Grabbing the lowest array count to make matching more fair
            int lowest_f_type = Math.Min(MyFavouriteTypes.Length, theirFavouriteTypes.Length);
            int lowest_l_type = Math.Min(MyLikedTypes.Length, theirLikedTypes.Length);
            int lowest_d_type = Math.Min(MyDislikedTypes.Length, theirDislikedTypes.Length);
            double possible_score = (lowest_f_type * PositiveMatchScore + lowest_l_type * SemiPositiveMatchScore) +
                                    (lowest_l_type * PositiveMatchScore + lowest_f_type * SemiPositiveMatchScore) +
                                    (lowest_d_type * SemiPositiveMatchScore);

            //// Get All drink match counts
            double f_f_matches = GetMatches(MyFavouriteTypes, theirFavouriteTypes) * PositiveMatchScore;
            double f_l_matches = GetMatches(MyFavouriteTypes, theirLikedTypes) * SemiPositiveMatchScore;
            double f_d_matches = GetMatches(MyFavouriteTypes, theirDislikedTypes) * NegativeMatchScore;
            double f_score = f_f_matches + f_l_matches + f_d_matches;

            double l_f_matches = GetMatches(MyLikedTypes, theirFavouriteTypes) * SemiPositiveMatchScore;
            double l_l_matches = GetMatches(MyLikedTypes, theirLikedTypes) * PositiveMatchScore;
            double l_d_matches = GetMatches(MyLikedTypes, theirDislikedTypes) * SemiNegativeMatchScore;
            double l_score = l_f_matches + l_l_matches + l_d_matches;

            double d_f_matches = GetMatches(MyDislikedTypes, theirFavouriteTypes) * NegativeMatchScore;
            double d_l_matches = GetMatches(MyDislikedTypes, theirLikedTypes) * SemiNegativeMatchScore;
            double d_d_matches = GetMatches(MyDislikedTypes, theirDislikedTypes) * SemiPositiveMatchScore;
            double d_score = d_f_matches + d_l_matches + d_d_matches;

            //Console.WriteLine($"{f_f_matches,3}, {f_l_matches,3}, {f_d_matches,3} = {f_score}");
            //Console.WriteLine($"{l_f_matches,3}, {l_l_matches,3}, {l_d_matches,3} = {l_score}");
            //Console.WriteLine($"{d_f_matches,3}, {d_l_matches,3}, {d_d_matches,3} = {d_score}");

            score += f_score + l_score + d_score;

            return score < 0 ? 0 : 1 / possible_score * score;
        }

        private static int GetMatches(string[] myList, string[] theirList)
        {
            return myList.Intersect(theirList).Count();
        }

        private static int GetMatches(DrinkType[] myList, DrinkType[] theirList)
        {
            return myList.Where(i => theirList.Contains(i)).Count();
        }
    }
}
