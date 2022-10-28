using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DB;

namespace DataModel
{
    public class PublicData
    {
        public PublicData()
        {
            data = new DataAccess();
        }
        private DataAccess data;
        public List<Public> Listing()
        {
            List<Public> List = new List<Public>();
            try
            {
                data.Query("select Id, Name from PublicTable");
                data.Read();
                while (data.PropReader.Read())
                {
                    Public aux = new Public();
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
