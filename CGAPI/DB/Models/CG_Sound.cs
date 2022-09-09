namespace CGAPI.DB.Models
{
    public class CG_Sound
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(16000)]
        public byte[] Sound { get; set; } = default!;
    }
}
