using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubRP.Models
{
    public class ClubDB : DbContext
    {
        public ClubDB() : base("name=ClubDB")
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        
    }
}