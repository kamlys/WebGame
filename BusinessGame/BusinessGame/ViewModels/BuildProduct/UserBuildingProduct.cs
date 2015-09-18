using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessGame.Models;

namespace BusinessGame.ViewModels.BuildProduct
{
    public class UserBuildingProduct
    {
        public List<UserBuildings> UBuilding { get; set; }

        public List<UserProducts> UProduct { get; set; }
    }
}