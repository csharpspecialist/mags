using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCodeFirstPrac1.Models
{
    public class Magazine
    {

            public int ID { get; set; }
            public string Title { get; set; }
            public string ISBN { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
        }

        public class MagazineDBContext : DbContext
        {
            public DbSet<Magazine> Mags { get; set; }
        }




    }
