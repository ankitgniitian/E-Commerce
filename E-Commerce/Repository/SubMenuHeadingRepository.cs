using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce.Models;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace E_Commerce.Repository
{
    public class SubMenuHeadingRepository : ISubMenuHeading
    {
        string dbcs = ConfigurationManager.ConnectionStrings["ECommerceModel"].ConnectionString;
        public int DeleteSubMenuHeading(SubMenuHeading subMenuHeading)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@SubMenuHeadingID", subMenuHeading.SubMenuHeadingID);
                parameter.Add("@SubMenuHeadingIDD", dbType: System.Data.DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Delete_SubMenuHeading", parameter, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameter.Get<int>("SubMenuHeadingIDD");
                return value;
            }
        }

        public IEnumerable<SubMenuHeading> GetAllSubMenu()
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                return con.Query<SubMenuHeading>("Load_All_SubMenuHeading", null, null, true, 0, commandType: CommandType.StoredProcedure);
            }
        }

        public SubMenuHeading GetSubMenuHeadingByID(SubMenuHeading subMenuHeading)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@SubMenuHeadingID", subMenuHeading.SubMenuHeadingID);
                try
                {
                    return con.Query<SubMenuHeading>("Load_SubMenuHeading_By_ID", parameter, null, true, 0, commandType: CommandType.StoredProcedure).Single();
                }
                catch
                {
                    return null;
                }
            }
        }

        public int InsertSubMenuHeading(SubMenuHeading subMenuHeading)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@SubMenuHeadingText",subMenuHeading.SubMenuHeadingText);
                parameter.Add("@MainMenuID", subMenuHeading.MainMenuID);
                parameter.Add("@IsActive", subMenuHeading.IsActive);
                parameter.Add("@SubMenuHeadingID",dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Save_SubMenuHeading", parameter, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameter.Get<int>("SubMenuHeadingID");
                return value;
            }
        }

        public int UpdateSubMenuHeading(SubMenuHeading subMenuHeading)
        {
            using (SqlConnection con = new SqlConnection(dbcs))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@SubMenuHeadingText", subMenuHeading.SubMenuHeadingText);
                parameter.Add("@MainMenuID", subMenuHeading.MainMenuID);
                parameter.Add("@IsActive",subMenuHeading.IsActive);
                parameter.Add("@SubMenuHeadingID", subMenuHeading.SubMenuHeadingID);
                parameter.Add("@SubMenuHeadingIDD", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Update_SubMenuHeading", parameter, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameter.Get<int>("SubMenuHeadingIDD");
                return value;
            }

        }
    }
}