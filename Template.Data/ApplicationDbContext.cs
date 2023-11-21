using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Base.Entities.Concrete;

namespace Template.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public override int SaveChanges()
        {

            return base.SaveChanges();
        }


        DbSet<User> Users { get; set; }
    }
}
