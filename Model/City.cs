using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Model;

[Table("cities")]
[PrimaryKey("Name")]
public class City
{
    public string Name { get; set; }
    public static List<City> ValidCities { get; set; }

    // Exists for EF
    public City()
    {
    }

    public City(string name)
    {
        Name = name;
    }

    public static List<City> GetValidCities()
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

        List<City> outputList = new List<City>();
        foreach (var item in array.ToList().Select(a => a["Title"]))
        {
            outputList.Add(new City((string)item));
        }
        ValidCities = outputList;
        return outputList;
    }

    public static List<City> getCitySearchResult(string city)
    {
        return ValidCities.OrderBy(a => LevenshteinDistance(a.Name.ToLower(), city.ToLower())).Take(10).ToList();
    }

    /// <summary>
    /// Compute the distance between two strings.
    /// </summary>
    /// 
    public static int LevenshteinDistance(string a, string b)
    {
        string s = (string)a;
        string t = (string)b;

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