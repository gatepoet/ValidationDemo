using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ValidationDemo.Models
{
    public class ValidationDemoContext : DbContext
    {
        public ValidationDemoContext() : base("DefaultConnection") { }
        public ValidationDemoContext(string connection) : base(connection) { }

        public DbSet<Booking> Bookings { get; set; }
    }
}