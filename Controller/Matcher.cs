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
        /// Constructor using mostly default values
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passingScore">Score needed for a user to be added to the MatchList</param>
        /// <param name="exactMatchInfluence">How much impact exact matches have on the final score, type matches are based on this value</param>
        public Matcher(double passingScore = 0.15, double exactMatchInfluence = 0.6)
        {
            try
            {
                User = Auth.User;
            }
            catch
            {
                throw new Exception("No user!");
            }
            // Excluding the logged-in user from all users
            // HACK: Should stil be fixed for official DB
            UserList = dummydb.Users.Where(u => u.Name != User.Name).ToList();

            MyFavouriteDrinks = User.GetFavourites().Select(d => d.Name).ToArray();
            MyLikedDrinks = User.GetLikes().Select(d => d.Name).ToArray();
            MyDislikedDrinks = User.GetDislikes().Select(d => d.Name).ToArray();

            MyFavouriteTypes = User.GetFavourites().Select(d => d.Type).ToArray();
            MyLikedTypes = User.GetLikes().Select(d => d.Type).ToArray();
            MyDislikedTypes = User.GetDislikes().Select(d => d.Type).ToArray();

            if (passingScore > 1)
            {
                throw new Exception("Passing score should be below 1!");
            }
            PassingScore = passingScore;

            ExactMatchInfluence = exactMatchInfluence;
            TypeMatchInfluence = 1.0 - exactMatchInfluence;

            // Some default values
            PositiveMatchScore = 4.0;
            NegativeMatchScore = -2.0;
            SemiPositiveMatchScore = 1.5;
            SemiNegativeMatchScore = -1.0;
        }

        /// <summary>
        /// Constructor using all custom values
        /// </summary>
        /// <param name="passingScore">Score needed for a user to be added to the MatchList. Between 0.0 and 1.0</param>
        /// <param name="exactMatchInfluence">How much impact exact matches have on the final score, type matches are based on this value</param>
        /// <param name="positiveMatchScore">How many points a positive match receives</param>
        /// <param name="negativeMatchScore">How many points a negative match receives</param>
        /// <param name="semiPositiveMatchScore">How many points a semi positive match receives</param>
        /// <param name="semiNegativeMatchScore">How many points a semi negative match receives</param>
        /// <exception cref="Exception"></exception>
        public Matcher(double passingScore, double exactMatchInfluence, double positiveMatchScore, double negativeMatchScore, double semiPositiveMatchScore, double semiNegativeMatchScore)
        {
            try
            {
                User = Auth.User;
            }
            catch
            {
                throw new Exception("No user!");
            }
            // Excluding the logged-in user from all users
            // HACK: Should stil be fixed for official DB
            UserList = dummydb.Users.Where(u => u.Name != User.Name).ToList();

            MyFavouriteDrinks = User.GetFavourites().Select(d => d.Name).ToArray();
            MyLikedDrinks = User.GetLikes().Select(d => d.Name).ToArray();
            MyDislikedDrinks = User.GetDislikes().Select(d => d.Name).ToArray();

            MyFavouriteTypes = User.GetFavourites().Select(d => d.Type).ToArray();
            MyLikedTypes = User.GetLikes().Select(d => d.Type).ToArray();
            MyDislikedTypes = User.GetDislikes().Select(d => d.Type).ToArray();


            if (passingScore > 1)
            {
                throw new Exception("Passing score should be below 1!");
            }
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
                // HACK: Good enough
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
        /// Checks how alike the logged in user is to the provided user. Checking the Exact matches
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
            int lowestFavoCount = Math.Min(MyFavouriteDrinks.Length, theirFavouriteDrinks.Length);
            int lowestLikeCount = Math.Min(MyLikedDrinks.Length, theirLikedDrinks.Length);
            int lowestHateCount = Math.Min(MyDislikedDrinks.Length, theirDislikedDrinks.Length);
            double possibleScore = lowestFavoCount * PositiveMatchScore +
                                   lowestLikeCount * PositiveMatchScore +
                                   lowestHateCount * SemiPositiveMatchScore;

            // Get All drink match counts
            double favoFavoMatches = GetMatches(MyFavouriteDrinks, theirFavouriteDrinks) * PositiveMatchScore;
            double favoLikeMatches = GetMatches(MyFavouriteDrinks, theirLikedDrinks) * SemiPositiveMatchScore;
            double favoHateMatches = GetMatches(MyFavouriteDrinks, theirDislikedDrinks) * NegativeMatchScore;
            double favoScore = favoFavoMatches + favoLikeMatches + favoHateMatches;

            double likeFavoMatches = GetMatches(MyLikedDrinks, theirFavouriteDrinks) * SemiPositiveMatchScore;
            double likeLikeMatches = GetMatches(MyLikedDrinks, theirLikedDrinks) * PositiveMatchScore;
            double likeHateMatches = GetMatches(MyLikedDrinks, theirDislikedDrinks) * SemiNegativeMatchScore;
            double likeScore = likeFavoMatches + likeLikeMatches + likeHateMatches;

            double hateFavoMatches = GetMatches(MyDislikedDrinks, theirFavouriteDrinks) * NegativeMatchScore;
            double hateLikeMatches = GetMatches(MyDislikedDrinks, theirLikedDrinks) * SemiNegativeMatchScore;
            double hateHateMatches = GetMatches(MyDislikedDrinks, theirDislikedDrinks) * SemiPositiveMatchScore;
            double hateScore = hateFavoMatches + hateLikeMatches + hateHateMatches;

            score += favoScore + likeScore + hateScore;
            // If the score is negative return 0, otherwise return the calculated score
            return score < 0 ? 0 : 1 / possibleScore * score;
        }

        /// <summary>
        /// Checks how alike the logged in user is to the provided user. Checking the DrinkType matches
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
            int lowestFavoCount = Math.Min(MyFavouriteTypes.Length, theirFavouriteTypes.Length);
            int lowestLikeCount = Math.Min(MyLikedTypes.Length, theirLikedTypes.Length);
            int lowestHateCount = Math.Min(MyDislikedTypes.Length, theirDislikedTypes.Length);
            double possibleScore = (lowestFavoCount * PositiveMatchScore + lowestLikeCount * SemiPositiveMatchScore) +
                                    (lowestLikeCount * PositiveMatchScore + lowestFavoCount * SemiPositiveMatchScore) +
                                    (lowestHateCount * SemiPositiveMatchScore);

            //// Get All drink match counts
            double favoFavoMatches = GetMatches(MyFavouriteTypes, theirFavouriteTypes) * PositiveMatchScore;
            double favoLikeMatches = GetMatches(MyFavouriteTypes, theirLikedTypes) * SemiPositiveMatchScore;
            double favoHateMatches = GetMatches(MyFavouriteTypes, theirDislikedTypes) * NegativeMatchScore;
            double favoScore = favoFavoMatches + favoLikeMatches + favoHateMatches;

            double likeFavoMatches = GetMatches(MyLikedTypes, theirFavouriteTypes) * SemiPositiveMatchScore;
            double likeLikeMatches = GetMatches(MyLikedTypes, theirLikedTypes) * PositiveMatchScore;
            double likeHateMatches = GetMatches(MyLikedTypes, theirDislikedTypes) * SemiNegativeMatchScore;
            double likeScore = likeFavoMatches + likeLikeMatches + likeHateMatches;

            double hateFavoMatches = GetMatches(MyDislikedTypes, theirFavouriteTypes) * NegativeMatchScore;
            double hateLikeMatches = GetMatches(MyDislikedTypes, theirLikedTypes) * SemiNegativeMatchScore;
            double hateHateMatches = GetMatches(MyDislikedTypes, theirDislikedTypes) * SemiPositiveMatchScore;
            double hateScore = hateFavoMatches + hateLikeMatches + hateHateMatches;

            score += favoScore + likeScore + hateScore;
            // If the score is negative return 0, otherwise return the calculated score
            return score < 0 ? 0 : 1 / possibleScore * score;
        }


        /// <summary>
        /// Returns the count of similar items between 2 arrays
        /// </summary>
        /// <param name="myList">An array of drinknames</param>
        /// <param name="theirList">An array of drinknames</param>
        /// <returns></returns>
        private static int GetMatches(string[] myList, string[] theirList)
        {
            return myList.Intersect(theirList).Count();
        }

        /// <summary>
        /// Returns the count of similar items between 2 arrays
        /// Overload for drinkTypes
        /// </summary>
        /// <param name="myList">An array of drinkTypes</param>
        /// <param name="theirList">An array of drinkTypes</param>
        /// <returns></returns>
        private static int GetMatches(DrinkType[] myList, DrinkType[] theirList)
        {
            return myList.Where(i => theirList.Contains(i)).Count();
        }
    }
}
