using Dapper;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Commerce.Repository
{
    public class LoginRepository : ILogin
    {
        string dbcs = ConfigurationManager.ConnectionStrings["ECommerceModel"].ToString();

        public Login CheckLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@username", username);
                parameter.Add("@password", password);
                return con.Query<Login>("CheckLogin", parameter, null, true, 0, commandType: System.Data.CommandType.StoredProcedure).Single();
            }
        }

        public int InsertLoginDetails(Login login)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@username", login.Username);
                parameter.Add("@password", login.Password);
                parameter.Add("@UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("SaveLoginDetails", parameter, null, 0, commandType: System.Data.CommandType.StoredProcedure);
                int value = parameter.Get<int>("UserID");
                return value;
            }


        }
    }
}