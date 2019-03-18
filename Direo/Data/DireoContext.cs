using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Direo.Models;

namespace Direo.Data
{
    public class DireoContext:DbContext
    {
        public DireoContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PlaceTag> PlaceTags { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PlaceStatus> PlaceStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
        public DbSet<UserLike> UserLikes { get; set; }
    }
}
