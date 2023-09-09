using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreLibrary.Model
{
    public class DataSerializer
    {
        public static void BinarySerializer(string filePath, List<Movie> movie)
        {
            using(FileStream fileStream = new FileStream(filePath,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movie);
            }
        }

        public static List<Movie> BinaryDesrializer(string filePath)
        {
            using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                List<Movie> movie = null;
                if (filePath.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movie = (List<Movie>)formatter.Deserialize(fileStream);
                }
                return movie;
            }
        }
    }
}
