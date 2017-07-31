using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repository
{
    public interface ILogin
    {
        Login CheckLogin(string username, string password);
        int InsertLoginDetails(Login login);
    }
}