// See https://aka.ms/new-console-template for more information
//Console.WriteLine(".NET MAUI is een bitch dus dit apparte project is nodig om EF werkend te krijgen..");
//Console.WriteLine("Thanks Microsoft!");
//Console.ReadLine();
using Newtonsoft.Json.Linq;
using Model;

User user = new("Bier Hater", "ik@haat.bier", "Bi3r!H@@t", new DateTime(2000, 1, 1));
user.FavouriteList = new int[] { 0, 1, 2 };
user.LikeList = new int[] { 3, 4, 5, 6, 7 };
user.DislikeList = new int[] { 8, 9, 10 };

//List<Drink> favo = user.GetFavourites();
//List<Drink> like = user.GetLikes();
//List<Drink> hate = user.GetDislikes();

return 0;

