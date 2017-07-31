using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;

namespace E_Commerce.Repository
{

    public class MainMenuRepository : IMainMenu
    {
        public int DeleteMainMenuByID(MainMenu menu)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceModel"].ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@MainMenuID", menu.MainMenuID);
                parameters.Add("@Error", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Delete_MainMenu", parameters, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameters.Get<int>("Error");
                return value;
            }
        }

        public IEnumerable<MainMenu> GetActiveMainMenu()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ConnectionString))
            {
                return con.Query<MainMenu>("Load_Active_MainMenu", null, null, true, 0, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<MainMenu> GetAllMainMenu()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ToString()))
            {
                return con.Query<MainMenu>("Load_All_MainMenu", null, null, true, 0, commandType: CommandType.StoredProcedure);
            }
        }

        public MainMenu GetMainMenuByID(int menuID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ToString()))
            {
                var para = new DynamicParameters();
                para.Add("@MainMenuID", menuID);
                return con.Query<MainMenu>("Load_MainMenu_By_ID", para, null, true, 0, commandType: CommandType.StoredProcedure).Single();
            }
        }

        public int InsertMainMenu(MainMenu menu)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ToString()))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@MainMenuText", menu.MainMenuText);
                parameter.Add("@IsActive", menu.IsActive);
                parameter.Add("@MainMenuID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Save_MainMenu", parameter, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameter.Get<int>("MainMenuID");
                return value;
            }
        }

        public int UpdateMainMenuByID(MainMenu menu)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECommerceModel"].ToString()))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@MainMenuText", menu.MainMenuText);
                parameter.Add("@IsActive", menu.IsActive);
                parameter.Add("@MainMenuID", menu.MainMenuID);
                parameter.Add("@MainMenuIDD", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Execute("Update_MainMenu", parameter, null, 0, commandType: CommandType.StoredProcedure);
                int value = parameter.Get<int>("MainMenuIDD");
                return value;
            }
        }
    }
}