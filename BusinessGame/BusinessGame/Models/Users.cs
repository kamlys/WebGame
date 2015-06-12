namespace BusinessGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public Users()
        {
            UserBuildings = new HashSet<UserBuildings>();
            UserProducts = new HashSet<UserProducts>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(300)]
        public string Email { get; set; }

        public DateTime Last_log { get; set; }

        public DateTime Registration_date { get; set; }

        public virtual Admins Admins { get; set; }

        public virtual Bans Bans { get; set; }

        public virtual Maps Maps { get; set; }

        public virtual ICollection<UserBuildings> UserBuildings { get; set; }

        public virtual ICollection<UserProducts> UserProducts { get; set; }
    }
}
