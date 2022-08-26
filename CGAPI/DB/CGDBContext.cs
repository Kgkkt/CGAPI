using Microsoft.EntityFrameworkCore;

namespace CGAPI.DB
{
    public class CGDBContext:DbContext
    {
        public CGDBContext(DbContextOptions<CGDBContext> options) : base(options)
        {
        }


        public DbSet<CGUser> CGUsers { get; set; }

        public DbSet<CG_Playlist> CG_Playlists { get; set; }

        public DbSet<CG_Text> CG_Texts { get; set; }

        public DbSet<CG_Sound> CG_Sounds { get; set; }

        public DbSet<CG_Image> CG_Images { get; set; }

        public DbSet<CG_GameElement> CG_GameElements { get; set; }
    }
}
