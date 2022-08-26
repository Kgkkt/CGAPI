namespace CGAPI.DB.Models
{
    public class CG_Image
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(16000)]
        public byte[] Img { get; set; }
    }
}
