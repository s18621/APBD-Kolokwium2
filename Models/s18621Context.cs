using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Kolokwium2.Models
{
    public class s18621Context : DbContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> championship_Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Team> Teams { get; set; }

        public s18621Context()
        {

        }

        public s18621Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.IdChampionship).ValueGeneratedOnAdd();
                opt.Property(p => p.OfficialName).HasMaxLength(100).IsRequired();
                opt.Property(p => p.Year).IsRequired();

            });
            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer).ValueGeneratedOnAdd();
                opt.Property(p => p.FirstName).HasMaxLength(30).IsRequired();
                opt.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                opt.Property(p => p.DateOfBirth).IsRequired();

            });
            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.IdTeam).ValueGeneratedOnAdd();
                opt.Property(p => p.TeamName).HasMaxLength(30).IsRequired();
                opt.Property(p => p.MaxAge).IsRequired();

            });
            modelBuilder.Entity<Championship_Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.Score).IsRequired();

                opt.HasOne(p => p.Team).WithMany(p => p.championship_Teams).HasForeignKey(p => p.IdTeam);
                opt.HasOne(p => p.Championship).WithMany(p => p.championship_Teams).HasForeignKey(p => p.IdChampionship);

            });
            modelBuilder.Entity<Player_Team>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.HasKey(p => p.IdTeam);

                opt.Property(p => p.NumonShirt).IsRequired();
                opt.Property(p => p.Comment).HasMaxLength(300);

                opt.HasOne(p => p.Player).WithMany(p => p.player_Teams).HasForeignKey(p => p.IdPlayer);
                opt.HasOne(p => p.Team).WithMany(p => p.player_Teams).HasForeignKey(p => p.IdTeam);

            });
        }

    }
}
