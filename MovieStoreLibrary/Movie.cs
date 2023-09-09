using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreLibrary
{
    [Serializable]
    public class Movie
    {
        private int _id;
        private string _name;
        private string _genre;
        private int _year;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Genre { get { return _genre; } }
        public int Year { get { return _year; } }

        public Movie(int id, string name, string genre, int year)
        {
            _id = id;
            _name = name;
            _genre = genre;
            _year = year;
        }
    }
}
