using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;

namespace Model
{
    public class Location
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public int Number { get; set; }
        public string Suffix { get; set; }

        public static List<string> ValidCities { get; set; }

        public static List<string> GetValidCities()
        {
            string output = string.Empty;
            string url = @"https://opendata.cbs.nl/ODataApi/OData/84734NED/Woonplaatsen";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }

            dynamic deserialized = JsonConvert.DeserializeObject(output);
            JArray array = deserialized.value;

            List<string> outputList = new List<string>();
            foreach (var item in array.ToList().Select(a => a["Title"]))
            {
                outputList.Add((string)item);
            }
            ValidCities = outputList;
            return outputList;
        }

        private static string _query = string.Empty;
        public static List<string> getCitySearchResult(string city)
        {
            _query = city;
            ValidCities.Sort(LevenshteinDistance);
            return ValidCities.Take(10).ToList();

            if (ValidCities.Contains(city))
            {
                return ValidCities.Where(a => a.Equals(city)).ToList();
            }

            return new List<string>();
        }

        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        /// 
        public static int LevenshteinDistance(string a, string b)
        {
            string s = (string)a;
            string t = _query;

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }


}
}
