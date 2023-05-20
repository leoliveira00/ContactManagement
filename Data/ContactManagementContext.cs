using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Models;

namespace ContactManagement.Data
{
    public class ContactManagementContext : DbContext
    {
        public ContactManagementContext (DbContextOptions<ContactManagementContext> options)
            : base(options)
        {
        }

        public DbSet<ContactManagement.Models.ContactMD> ContactMD { get; set; } = default!;
    }
}
