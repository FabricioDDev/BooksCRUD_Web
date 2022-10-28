using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DomainModel;

namespace DataModel
{
    public class GenreData
    {
        public GenreData()
        {
            data = new DataAccess();
        }
        private DataAccess data;

        public List<Genre> Listing()
        {
            List<Genre> List = new List<Genre>();
            try
            {
                data.Query("select Id, Name from CategoryTable");
                data.Read();
                while (data.PropReader.Read())
                {
                    Genre aux = new Genre();
                    aux.Id = (int)data.PropReader["Id"];
                    aux.Name = (string)data.PropReader["Name"];
                    List.Add(aux);
                }
                return List;
            }
            catch (Exception ex) {
                throw ex;
            }
            finally { data.Close(); }
    }
}
