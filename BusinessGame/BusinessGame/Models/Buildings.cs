namespace BusinessGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Buildings
    {
        public Buildings()
        {
            UserBuildings = new HashSet<UserBuildings>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Price { get; set; }

        public int Percenth_price_per_lvl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Product_per_lvl { get; set; }

        public int Dest_price { get; set; }

        public int Percent_product_per_lvl { get; set; }

        public int Product_ID { get; set; }

        public virtual Products Products { get; set; }

        public virtual ICollection<UserBuildings> UserBuildings { get; set; }
    }
}
