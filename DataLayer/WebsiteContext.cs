using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext()
            : base("name=DefaultConnection")
        {

        }
       public DbSet<Article> Articles { get; set; }
      
    }
}
