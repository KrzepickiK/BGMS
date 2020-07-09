using BGMS_Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGMS_Repository.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name = BgmsConnection")
        {
        }

        public DbSet<GameModel> Game { get; set; }
        public DbSet<GameDisplayinformationModel> GameDisplays { get; set; }
    }
}
