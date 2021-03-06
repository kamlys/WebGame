namespace BusinessGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public Products()
        {
            Buildings = new HashSet<Buildings>();
            UserProducts = new HashSet<UserProducts>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int Price_per_unit { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        public virtual ICollection<Buildings> Buildings { get; set; }

        public virtual ICollection<UserProducts> UserProducts { get; set; }
    }
}
