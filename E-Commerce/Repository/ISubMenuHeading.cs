using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repository
{
    public interface ISubMenuHeading
    {
        int InsertSubMenuHeading(SubMenuHeading subMenuHeading);

        int UpdateSubMenuHeading(SubMenuHeading subMenuHeading);

        int DeleteSubMenuHeading(SubMenuHeading subMenuHeading);

        IEnumerable<SubMenuHeading> GetAllSubMenu();

        SubMenuHeading GetSubMenuHeadingByID(SubMenuHeading subMenuHeading);
        
    }
}