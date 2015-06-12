namespace BusinessGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bans
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int User_ID { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Start_date { get; set; }

        public DateTime Finish_date { get; set; }

        public virtual Users Users { get; set; }
    }
}
