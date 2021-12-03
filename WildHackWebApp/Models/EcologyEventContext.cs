using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildHackWebApp.Models
{
    public class EcologyEventContext : DbContext
    {
        public EcologyEventContext(DbContextOptions<EcologyEventContext> options)
            : base(options)
        {
        }

        public DbSet<EcologyEvent> EcologyEvents { get; set; }
    }
}
