using MovieStoreLibrary.ExceptionFolder;
using MovieStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStoreLibrary.Services
{
    public class MovieManager
    {
        public static string filePath = @"D:\DotNet\MovieStoreAppWithList\MovieStoreApp\MovieObjectStore";
        static List<Movie> moviesList = new List<Movie>();
        public static int GetMoviesCount { get { return moviesList.Count; } }
        public MovieManager()
        {
            moviesList = DataSerializer.BinaryDesrializer(filePath);
        }
        public static Movie GetMovieListByIndex(int index)
        {
            return moviesList[index];
        }
        public static Movie FindMovieByYear(int inputYear)
        {
            if(moviesList.Count == 0)
            {
                throw new MovieListEmptyException("Movie List is empty");
            }
            return moviesList.Find(item => item.Year == inputYear);
        }
        public static Movie FindMovieByName(string movieName)
        {
            if (moviesList.Count == 0)
            {
                throw new MovieListEmptyException("Movie List is empty");
            }
            return moviesList.Find(item => item.Name == movieName);
        }


        public static void AddMovies(int id,string name,string genre,int year)
        {

            Movie newMovie = new Movie(id, name, genre, year);
            moviesList.Add(newMovie);
            DataSerializer.BinarySerializer(filePath, moviesList);
        }

        public static void RemoveMovieByNmae(string movieName)
        {

            if (moviesList.Count == 0)
            {
                throw new MovieListEmptyException("Movie List is empty");
            }
            var findMovieNameIndex = FindMovieByName(movieName);
            moviesList.Remove(findMovieNameIndex);
            DataSerializer.BinarySerializer(filePath, moviesList);
            
        }
        public static void ClearMoviesList()
        {

            if (moviesList.Count == 0)
            {
                throw new MovieListEmptyException("Movie List is empty");
            }
            moviesList.Clear();
            DataSerializer.BinarySerializer(filePath, moviesList);
        }
    }
}
