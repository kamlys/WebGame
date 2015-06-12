namespace BusinessGame.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class game_BusinessDb : DbContext
    {
        public game_BusinessDb()
            : base("name=game_BusinessDb")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Bans> Bans { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Maps> Maps { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserBuildings> UserBuildings { get; set; }
        public virtual DbSet<UserProducts> UserProducts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buildings>()
                .HasOptional(e => e.UserBuildings)
                .WithRequired(e => e.Buildings);

            modelBuilder.Entity<Products>()
                .HasOptional(e => e.Buildings)
                .WithRequired(e => e.Products);

            modelBuilder.Entity<Products>()
                .HasOptional(e => e.UserProducts)
                .WithRequired(e => e.Products);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Admins)
                .WithRequired(e => e.Users);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Bans)
                .WithRequired(e => e.Users);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Maps)
                .WithRequired(e => e.Users);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserBuildings)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserProducts)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
