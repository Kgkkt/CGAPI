namespace CGAPI.DB.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class CGUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public List<CG_Playlist> Playlists { get; set; }
    }
}
