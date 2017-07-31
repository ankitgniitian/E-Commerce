using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repository
{
    public interface IMainMenu
    {
        IEnumerable<MainMenu> GetAllMainMenu();

        IEnumerable<MainMenu> GetActiveMainMenu();

        MainMenu GetMainMenuByID(int menuID);

        int InsertMainMenu(MainMenu menu);

        int UpdateMainMenuByID(MainMenu menu);

        int DeleteMainMenuByID(MainMenu menu);
    }
}