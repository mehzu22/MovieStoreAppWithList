using MovieStoreLibrary.Services;
using MovieStoreLibrary.ExceptionFolder;
using MovieStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreLibrary;

namespace MovieStoreApp.Controller
{
    internal class MovieController
    {
        
        public static void MainMenu()
        {
            char choice;

            new MovieManager();
            do
            {
                Console.WriteLine("\n******* Welcome to Movies App *******");
                Console.WriteLine($"Movie Status : {MovieManager.GetMoviesCount}/5");
                Console.WriteLine("What you want to do..." +
                    "Please select from the below options");
                Console.WriteLine("1.Display All Movies" +
                    "\n2.Display Movie by year " +
                    "\n3.Add Movie\n4.Remove Movie by name" +
                    "\n5.Clear all movies" +
                    "\n6.Exit" +
                    "\n(Enter the option number)\n");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (choice)
                {
                    case '1':
                        DisplayAllMovies();

                        break;

                    case '2':
                        DisplayMovieByYear();
                        break;

                    case '3':
                        AddMovie();
                        break;

                    case '4':
                        RemoveMovieByName();
                        break;

                    case '5':
                        ClearAllMovie();
                        break;

                    case '6':
                        Console.WriteLine("Exiting application! \nHave a nice day!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option!\nPlease choose proper option");
                        break;
                }
            } while (choice != '6');

        }

        static void DisplayAllMovies()
        {
            //moviesList = DataSerializer.BinaryDesrializer(filePath);
            try
            {
                if (MovieManager.GetMoviesCount == 0)
                {
                    Console.WriteLine("\nOops! No Movies to show.. ");
                    return;
                }
                Console.WriteLine("------------- All Movies -------------");
                for (int i = 0; i < MovieManager.GetMoviesCount; i++)
                {
                    Console.WriteLine($"\n********** Movie {i + 1} *********");
                    //movies list should be return from manager class
                    var move = MovieManager.GetMovieListByIndex(i);
                    Console.WriteLine($"ID: {move.Id},\nName: {move.Name},\nGenre: {move.Genre}, \nYear: {move.Year}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); 
            } 
           
        }

        static void DisplayMovieByYear()
        {
            try
            {
                
                if (MovieManager.GetMoviesCount == 0)
                {
                    Console.WriteLine("\nOops! No Movies to show.. ");
                    return;
                }
                Console.WriteLine("Enter the year Off which you want to see movie : \n");
                int inputYear = Convert.ToInt32(Console.ReadLine());
                Movie findMovie = MovieManager.FindMovieByYear(inputYear);
                if (findMovie != null)
                {
                    Console.WriteLine($"-------- Movie of year {inputYear} is --------");
                    Console.WriteLine($"\nID: {findMovie.Id}," +
                        $"\nName: {findMovie.Name}," +
                        $"\nGenre: {findMovie.Genre}, " +
                        $"\nYear: {findMovie.Year}");
                }
                else
                {
                    Console.WriteLine($"Oopss! there's no movie of {inputYear} year");
                }
            }
            catch (Exception e)
            {
                    Console.WriteLine(e.Message );
            }
        }

        static void AddMovie()
        {
            try
            {
                if (MovieManager.GetMoviesCount >= 5)
                {
                    Console.WriteLine("Oopss! Movie List is full can't add new movies.");
                    return;
                }
                Console.WriteLine("Enter Movie Id :");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Movie Name :");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Genre of movie:");
                string genre = Console.ReadLine();

                Console.WriteLine("Enter year of establishment of Movie :");
                int year = Convert.ToInt32(Console.ReadLine());


                MovieManager.AddMovies(id, name, genre, year);
                Console.WriteLine("\nMovie added successfully!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static void RemoveMovieByName()
        {
            try
            {
                Console.WriteLine("Enter the name of movie which you wish to remove : \n");
                string movieName = Console.ReadLine();
                MovieManager.RemoveMovieByNmae(movieName);
                Console.WriteLine("Movie removed sucessfully!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        static void ClearAllMovie()
        {
            try
            {
                MovieManager.ClearMoviesList();
                Console.WriteLine("Cleared all movies!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
