﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Models;

namespace ProvaTecnica.Data
{
    public class ProvaTecnicaContext : DbContext
    {
        public ProvaTecnicaContext (DbContextOptions<ProvaTecnicaContext> options)
            : base(options)
        {
        }

        public DbSet<ProvaTecnica.Models.Category> Category { get; set; }
    }
}