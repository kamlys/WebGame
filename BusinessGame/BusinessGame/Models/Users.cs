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
            Admins = new HashSet<Admins>();
            Bans = new HashSet<Bans>();
            Maps = new HashSet<Maps>();
            UserBuildings = new HashSet<UserBuildings>();
            UserProducts = new HashSet<UserProducts>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(300)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Last_log { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Registration_Date { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime? Last_Update { get; set; }

        public virtual ICollection<Admins> Admins { get; set; }

        public virtual ICollection<Bans> Bans { get; set; }

        public virtual ICollection<Maps> Maps { get; set; }

        public virtual ICollection<UserBuildings> UserBuildings { get; set; }

        public virtual ICollection<UserProducts> UserProducts { get; set; }
    }
}
