using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SolsticeAPIChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeAPIChallenge.Models
{
    public partial class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}

