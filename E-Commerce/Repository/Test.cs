using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Commerce.Repository
{
    public class Test : ITest
    {
        public IEnumerable<E_Commerce.Models.Test> GetAllTest()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ConnectionString))
            {
               return con.Query<E_Commerce.Models.Test>("Testsp", null, null, true, 0, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}