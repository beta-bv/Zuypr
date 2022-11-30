using System.Drawing;

namespace Model
{
    // All the code in this file is included in all platforms.
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public List<string> Cities { get; set; }
        public Bitmap ProfielImage { get; set; }
        public List<User> Matches { get; set; }
    }
}