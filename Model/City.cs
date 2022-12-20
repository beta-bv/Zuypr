using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model;

[Table("cities")]
[PrimaryKey("Name")]
public class City
{
    public string Name { get; set; }

    // Exists for EF
    public City()
    {
    }

    public City(string name)
    {
        Name = name;
    }
}