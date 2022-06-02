using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using dotnet6_webapi_jwt.Models;

namespace dotnet6_webapi_jwt.Data;
// {
    public partial class ApiDbContext : IdentityDbContext<IdentityUser>
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestDB;User ID=SA;Password=Sql@12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<ItemData>? ItemData { get; set; }
    }
// }
