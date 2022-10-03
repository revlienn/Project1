using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<Staff> Staffs {get;set;}
        public DbSet<Contact> Contacts{get;set;}
        public DbSet<Organisation> Organisations{get;set;}
        public DbSet<Project> Projects{get;set;}
        
    }
}