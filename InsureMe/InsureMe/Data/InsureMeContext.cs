using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InsureMe.Models
{
    public class InsureMeContext : DbContext
    {
        public InsureMeContext (DbContextOptions<InsureMeContext> options)
            : base(options)
        {
        }

        public DbSet<InsureMe.Models.User> User { get; set; }
    }
}
