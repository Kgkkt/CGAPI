using CGAPI.GLOB;

namespace CGAPI.DB.Models
{
    public class CG_Playlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CGUserId { get; set; }

        public PlayListTypes Type { get; set; }

        [ForeignKey(nameof(CGUserId))]
        public CGUser CGUser { get; set; }

    }
}
