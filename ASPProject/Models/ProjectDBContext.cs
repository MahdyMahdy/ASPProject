using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class ProjectDBContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Login> logins { get; set; }

    }
}