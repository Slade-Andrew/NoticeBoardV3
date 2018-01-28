using NoticeBoardV3.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NoticeBoardV3.DAL
{
    public class NoticeboardContext : DbContext
    {
        public NoticeboardContext() : base("NoticeboardDatabase") { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<PerOrg> PerOrgs { get; set; }
        public DbSet<PerOrgLocation> PerOrgLocations { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardType> BoardTypes { get; set; }
        public DbSet<ViewableBoard> ViewableBoards { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<NoticeStatus> NoticeStatuses { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<MemberOf> MemberOfs { get; set; }
        public DbSet<MemberOfRole> MemerberOfRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Notice>()
                .HasRequired(n => n.PerOrg)
                .WithMany(po => po.Notices)
                .HasForeignKey(n => n.PerOrg_ID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}