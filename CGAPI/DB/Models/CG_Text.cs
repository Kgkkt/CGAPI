namespace CGAPI.DB.Models
{
    public class CG_Text
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
    }
}
