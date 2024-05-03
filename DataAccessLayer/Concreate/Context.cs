using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer.Concreate
{
    public class Context:IdentityDbContext<User,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=213.238.183.40\MSSQLSERVER2019;Initial Catalog=enocaDB;User=enoca;password=N47d6ml8!;TrustServerCertificate=true");
            // CampusGo cmpsflw   0Xdbq=Xt!A#lBIQo
        }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<Siparis>()
                .HasOne(s => s.Firma)
                .WithMany(f => f.Siparisler)
                .HasForeignKey(s => s.FirmaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Siparis>()
                .HasOne(s => s.Urun)
                .WithMany(u => u.Siparisler)
                .HasForeignKey(s => s.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

        }


    }

}
