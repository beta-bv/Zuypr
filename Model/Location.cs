using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        public static List<string> getCitySearchResult(string city) 
        {
            if (ValidCities.Contains(city))
            {
                return ValidCities.Where(a => a.Equals(city, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return new List<string>();
        }
    }
}
