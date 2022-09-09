namespace CGAPI.DB.Models
{
    public class CG_GameElement
    {
        public int Id { get; set; }

        public int CG_ImageId { get; set; }

        public int CG_SoundQuestionId { get; set; }

        public int CG_SoundCorrectAnswerId { get; set; }

        public int CG_SoundWrongAnswerId { get; set; }

        public int CG_PlaylistId { get; set; }

        [ForeignKey(nameof(CG_PlaylistId))]
        public CG_Playlist CG_Playlist { get; set; }


        [ForeignKey(nameof(CG_ImageId))]
        public CG_Image CG_Image { get; set; }

        [ForeignKey(nameof(CG_SoundQuestionId))]
        public CG_Sound CG_SoundQuestion { get; set; }

        [ForeignKey(nameof(CG_SoundCorrectAnswerId))]
        public CG_Sound CG_SoundCorrectAnswer{ get; set; }

        [ForeignKey(nameof(CG_SoundWrongAnswerId))]
        public CG_Sound CG_SoundWrongAnswer { get; set; }

    }
}
