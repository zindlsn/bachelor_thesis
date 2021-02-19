using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery
{
    /// <summary>
    /// Represents the service communication with the database.
    /// </summary>
    public class DatabaseService
    {
        private static readonly string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\Bachelor_Arbeit\Code\code\C#\ImageGallery\ImageGalleryDb.mdf;Integrated Security=True";

        /// <summary>
        /// Saves a picture into the database.
        /// </summary>
        /// <param name="picture"></param>
        public void InsertPicture(Picture picture)
        {
            using (SqlConnection connection = new SqlConnection(
               ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Picture (Path,Name) VALUES (@path,@name)", connection);
                    command.Parameters.Add("@path", System.Data.SqlDbType.VarChar).Value = picture.Path;
                    command.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = picture.Title;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Loads pictures filtered.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Picture GetPicture(PictureFilter filter)
        {
            Picture picture = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("(SELECT * FROM Picture WHERE path = @path)", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                picture = new Picture()
                                {
                                    Path = reader.GetValue(2).ToString(),
                                    Title = reader.GetValue(1).ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    picture = null;
                }
            }

            return picture;
        }

        /// <summary>
        /// Loads pictures filtered.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Picture> GetPictures(PictureFilter filter)
        {
            List<Picture> pictures;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("(SELECT * FROM Picture)", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            pictures = new List<Picture>();
                            while (reader.Read())
                            {
                                Picture picture = new Picture()
                                {
                                    Path = reader.GetValue(2).ToString(),
                                    Title = reader.GetValue(1).ToString()
                                };
                                pictures.Add(picture);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    pictures = null;
                }
            }

            return pictures;
        }
    }
}
