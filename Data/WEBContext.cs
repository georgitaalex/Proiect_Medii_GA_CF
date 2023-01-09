using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB.Models;

namespace WEB.Data
{
    public class WEBContext : DbContext
    {
        public WEBContext (DbContextOptions<WEBContext> options)
            : base(options)
        {
        }

        public DbSet<WEB.Models.Sport> Sport { get; set; }

        public DbSet<WEB.Models.Instructor> Instructor { get; set; }
        public DbSet<WEB.Models.Categorie> Categorie { get; set; }
        public DbSet<WEB.Models.Locatie> Locatie { get; set; }
    }
}
