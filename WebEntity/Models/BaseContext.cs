using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebEntity.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<Int32>("ChequeIdNum").StartsAt(1).IncrementsBy(1).IsCyclic(true).HasMin(1).HasMax(2147483647);

            modelBuilder.HasSequence<Int32>("PositionIdNum").StartsAt(1).IncrementsBy(1).IsCyclic(true).HasMin(1).HasMax(2147483647);

            modelBuilder.Entity<Cheque>().HasKey(x => new { x.Id });

            modelBuilder.Entity<Cheque>().Property(x => x.Id).HasDefaultValueSql("next value for ChequeIdNum");

            modelBuilder.Entity<Position>().HasKey(x => new { x.Id });

            modelBuilder.Entity<Position>().Property(x => x.Id).HasDefaultValueSql("next value for PositionIdNum");

            modelBuilder.Entity<Cheque>().HasMany(x => x.Positions);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseSqlServer("Server=IT-FABRIKA-001;Database=ef_base;User Id=sa;Password=240580;");
            
        }
    }
}
