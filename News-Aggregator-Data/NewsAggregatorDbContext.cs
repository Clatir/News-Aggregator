using Microsoft.EntityFrameworkCore;
using News_Aggregator_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Aggregator_Data
    
{
    public class News_AggregatorDbContext:DbContext
    {
        public DbSet<ARticle> ARticles { get; set; }
        public DbSet<COmment> COmments { get; set; }
        public DbSet<USer> USers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S59I6HT;Database=NewsAggregatorDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ARticle>()
                .HasOne(a => a.USers)
                .WithMany(u => u.ARticles)
                .HasForeignKey(a => a.AR_user_id)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<COmment>()
                .HasOne(c => c.ARticle)
                .WithMany(a => a.COmments)
                .HasForeignKey(c => c.CO_art_id)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<COmment>()
                .HasOne(c => c.USer)
                .WithMany(u => u.COmments)
                .HasForeignKey(c => c.CO_user_id)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
