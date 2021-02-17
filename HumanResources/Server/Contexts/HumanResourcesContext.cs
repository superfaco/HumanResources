using HumanResources.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Server.Contexts
{
    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext() { }

        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options) : base(options){}

        public DbSet<Gender> Gender { get; set; }
    }
}
