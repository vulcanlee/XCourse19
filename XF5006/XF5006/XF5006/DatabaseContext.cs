using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        //private string _databasePath = SCLHelper.DBPath;
        private string _databasePath =
         System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), SCLHelper.DBPath);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
