using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessGame.Models;

namespace BusinessGame.ViewModels.BuildProduct.Building
{
    public class U_Building
    {
        public int User_ID { get; set; }
        public string BuildingName { get; set; }
        public int x_left { get; set; }
        public int x_right { get; set; }
        public int y_top { get; set; }
        public int y_bottom { get; set; }
        public int BuildingLvl { get; set; }
        public int Buidling_ID { get; set; }
    }
}