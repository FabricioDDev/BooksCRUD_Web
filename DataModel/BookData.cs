using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class BookData
    {
        public BookData()
        {
            data = new DataAccess();
        }
        private DataAccess data;
        public List<Book> ListingSP()
        {
            List<Book> List = new List<Book>();
            try
            {
                data.SP("BookListSP");
                data.Read();
                while (data.PropReader.Read())
                {
                    Book aux = new Book();
                    aux.Id = (int)data.PropReader["IdBook"];
                    aux.Title = (string)data.PropReader["Title"];
                    aux.Description = (string)data.PropReader["Description"];
                    aux.Author = (string)data.PropReader["Author"];
                    aux.Year = (int)data.PropReader["Year"];
                    aux.Url = (string)data.PropReader["Url"];
                    aux.Cover = (string)data.PropReader["Cover"];
                    aux.Category = new Category();
                    aux.Category.Id = (int)data.PropReader["Id"];
                    aux.Category.Name = (string)data.PropReader["Name"];
                    aux.Genre = new Genre();
                    aux.Genre.Id = (int)data.PropReader["Id"];
                    aux.Genre.Name = (string)data.PropReader["Name"];
                    aux.Public = new Public();
                    aux.Public.Id = (int)data.PropReader["Id"];
                    aux.Public.Name = (string)data.PropReader["Name"];
                    List.Add(aux);
                }
                return List;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
    }
}
