using Games_Report__CodeFirst_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Games_Report__CodeFirst_
{
    public class GameStorageContext : DbContext
    {
        public DbSet<GameInfo> GameInfos {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source = PC; Initial Catalog = GameInfo;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameStorageContext).Assembly);

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var game1 = new GameInfo { Id = -1, Title = "12", Creator = "PCF", Style = "RPG" };

            var game2 = new GameInfo { Id = -2, Title = "1676", Creator = "Bioware", Style = "Shooter"};

            var game3 = new GameInfo { Id = -3, Title = "121", Creator = "P56", Style = "R12" };

            modelBuilder.Entity<GameInfo>().HasData(game1);
            modelBuilder.Entity<GameInfo>().HasData(game2);
            modelBuilder.Entity<GameInfo>().HasData(game3);
        }
    }

    
}
