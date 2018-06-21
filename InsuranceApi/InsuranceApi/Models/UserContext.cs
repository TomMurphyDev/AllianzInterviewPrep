using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace InsuranceApi.Models
{
    /*
     * database context is the main class that coordinates Entity Framework functionality for a given data model.
     */
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<UserItem> UserItems { get; set; }
    }
}
