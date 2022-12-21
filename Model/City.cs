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

    public override bool Equals(object obj)
    {
        City city = obj as City;
        return this.Name == city.Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}