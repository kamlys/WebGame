﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessGame.ViewModels.BuildProduct.Building;
using BusinessGame.ViewModels.BuildProduct.Product;
using BusinessGame.Models;

namespace BusinessGame.ViewModels.BuildProduct
{
    public class UserBuildingProduct
    {
        public List<U_Building> UBuilding { get; set; }

        public List<U_Product> UProduct { get; set; }

        public Maps UMap { get; set; }
    }
}