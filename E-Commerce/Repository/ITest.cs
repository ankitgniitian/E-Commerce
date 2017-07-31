using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repository
{
    public interface ITest
    {
        IEnumerable<E_Commerce.Models.Test> GetAllTest();
    }
}