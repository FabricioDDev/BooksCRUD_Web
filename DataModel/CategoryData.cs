using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class CategoryData
    {
        public CategoryData()
        {
            data = new DataAccess();
        }
        private DataAccess data;
        public List<Category> Listing()
        {
            List<Category> List = new List<Category>();
            try
            {
                data.Query("select Id, Name from CategoryTable");
                data.Read();
                while (data.PropReader.Read())
                {
                    Category aux = new Category();
                    aux.Id = (int)data.PropReader["Id"];
                    aux.Name = (string)data.PropReader["Name"];
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
    }
}
