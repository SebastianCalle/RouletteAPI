using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RouletteApi.Models;

namespace RouletteApi.Data
{
    public partial class RouletteApiContext : DbContext
    {
        public RouletteApiContext()
        {
        }

        public RouletteApiContext(DbContextOptions<RouletteApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bet { get; set; }
        public virtual DbSet<Roulette> Roulette { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Roulette)
                    .WithMany(p => p.Bet)
                    .HasForeignKey(d => d.RouletteId)
                    .HasConstraintName("FK_Bet_Roulette");
            });

            modelBuilder.Entity<Roulette>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
