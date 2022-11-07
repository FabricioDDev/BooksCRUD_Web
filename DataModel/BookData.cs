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

        //SobreCarga1
        public List<Book> FilterList(string Filter)
        {
            try
            {
                List<Book> List = ListingSP().FindAll(
                    x => x.Title.ToUpper().Contains(Filter.ToUpper())
                    || x.Author.ToUpper().Contains(Filter.ToUpper()));
                return List;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Book> FilterList(string Camp, string Criterion)
        {
            List<Book> List = new List<Book>();
            try
            {
                string Query = "select B.IdBook, B.Title, B.Description, B.Author, B.Year, B.Url, B.Cover, C.Id as Cid, C.Name as CName, G.Id as Gid, G.Name as GName, P.Id as Pid, P.Name as PName from BookTable B, CategoryTable C, GenreTable G, PublicTable P WHERE IdCategory = C.Id and IdGenre = G.Id and IdPublic = P.Id and ";
                if (Camp == "Category")
                {
                    switch (Criterion)
                    {
                        case "Novel":
                            Query += "C.id = 3";
                            break;
                        case "Comics":
                            Query += "C.id = 4";
                            break;
                        case "Anime":
                            Query += "C.id = 5";
                            break;
                        default:
                            break;
                    }
                }
                else if (Camp == "Genre")
                {
                    switch (Criterion)
                    {
                        case "Comedy":
                            Query += "G.id = 1";
                            break;
                        case "Romance":
                            Query += "G.id = 2";
                            break;
                        case "Horror":
                            Query += "G.id = 4";
                            break;
                        case "Fiction":
                            Query += "G.id = 5";
                            break;
                        case "Accion":
                            Query += "G.id = 6";
                            break;
                        case "Fancy":
                            Query += "G.id = 7";
                            break;
                        case "Mystery":
                            Query += "G.id = 8";
                            break;
                        case "Adventure":
                            Query += "G.id = 9";
                            break;
                        default:
                            break;
                    }
                }
                else if (Camp == "Public")
                {
                    switch (Criterion)
                    {
                        case "Kids":
                            Query += "P.id = 2";
                            break;
                        case "Adult":
                            Query += "P.id = 3";
                            break;
                        default:
                            break;
                    }
                }

                data.Query(Query);
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
                    aux.Category.Id = (int)data.PropReader["Cid"];
                    aux.Category.Name = (string)data.PropReader["CName"];

                    aux.Genre = new Genre();
                    aux.Genre.Id = (int)data.PropReader["Gid"];
                    aux.Genre.Name = (string)data.PropReader["GName"];

                    aux.Public = new Public();
                    aux.Public.Id = (int)data.PropReader["Pid"];
                    aux.Public.Name = (string)data.PropReader["PName"];
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
