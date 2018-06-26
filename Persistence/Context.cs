﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Tutorial.Models;



namespace Tutorial.Persistence
{
    public class Context : IdentityDbContext<Usuario>
    { 

        public Context() : base("DefaultConnection", throwIfV1Schema: false) { }

         
        //public DbSet<Cavalo> Cavalos { get; set; }

         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("CASA");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");
             

            modelBuilder.Entity<Usuario>()
               .ToTable("Usuarios")
               .Property(p => p.Id)
               .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUserRole>()
               .ToTable("UsuariorPapel");

            modelBuilder.Entity<IdentityUserLogin>()
               .ToTable("Logins");

            modelBuilder.Entity<IdentityUserClaim>()
               .ToTable("Claims");

            modelBuilder.Entity<IdentityRole>()
               .ToTable("Papeis");

            modelBuilder
            .Properties()
            .Where(p => p.PropertyType == typeof(string))
            .Configure(p => p.IsUnicode(false));

            modelBuilder
           .Properties()
           .Where(p => p.PropertyType == typeof(string) &&
                      p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0)
           .Configure(p => p.HasMaxLength(256));


            

        }


        public static Context Create()
        {
            return new Context();
        }





    }
}