using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamingAppPractice.Models;

namespace GamingAppPac3.Data
{
    public class GamingAppPac3Context : DbContext
    {
        public GamingAppPac3Context (DbContextOptions<GamingAppPac3Context> options)
            : base(options)
        {
        }

        public DbSet<GamingAppPractice.Models.Game> Game { get; set; } = default!;
        public DbSet<GamingAppPractice.Models.Gamer> Gamer { get; set; } = default!;
        public DbSet<GamingAppPractice.Models.Gamer_Game> Gamer_Game { get; set; } = default!;
    }
}
