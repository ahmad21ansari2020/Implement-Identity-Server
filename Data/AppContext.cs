﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {

        }
    }
}
