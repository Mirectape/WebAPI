using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-ECEJ6EC\SQLEXPRESS;
                  DataBase=PersonDB;
                  Trusted_Connection=True;
                  Encrypt=false"
                );
        }
    }
}
