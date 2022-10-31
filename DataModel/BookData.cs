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
                data.SP("BookList_SP");
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
                    aux.Category.Id = (int)data.PropReader["IdC"];
                    aux.Category.Name = (string)data.PropReader["NameC"];

                    aux.Genre = new Genre();
                    aux.Genre.Id = (int)data.PropReader["IdG"];
                    aux.Genre.Name = (string)data.PropReader["NameG"];

                    aux.Public = new Public();
                    aux.Public.Id = (int)data.PropReader["IdP"];
                    aux.Public.Name = (string)data.PropReader["NameP"];
                    List.Add(aux);
                }
                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }

        public void InsertSP(Book New)
        {
            try
            {
                data.SP("BookInsertSP");
                data.Parameters("@Title", New.Title);
                data.Parameters("@Description", New.Description);
                data.Parameters("@Author", New.Author);
                data.Parameters("@Year", New.Year);
                data.Parameters("@Url", New.Url);
                data.Parameters("@Cover", New.Cover);
                data.Parameters("@IdCategory", New.Category.Id);
                data.Parameters("@IdGenre", New.Genre.Id);
                data.Parameters("@IdPublic", New.Public.Id);
                data.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }

        }
        public void UpdateSP(Book New)
        {
            try
            {
                data.SP("BookUpdateSP");
                data.Parameters("@IdBook", New.Id);
                data.Parameters("@Title", New.Title);
                data.Parameters("@Description", New.Description);
                data.Parameters("@Author", New.Author);
                data.Parameters("@Year", New.Year);
                data.Parameters("@Url", New.Url);
                data.Parameters("@Cover", New.Cover);
                data.Parameters("@IdCategory", New.Category.Id);
                data.Parameters("@IdGenre", New.Genre.Id);
                data.Parameters("@IdPublic", New.Public.Id);
                data.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }

        }
    
        public void DeleteSP(int Id)
        {
            try
            {
                data.SP("BookDeleteSP");
                data.Parameters("@Id", Id);
                data.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { data.Close(); }
        }
    }
}
