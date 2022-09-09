namespace CGAPI.VModels
{
    public class GetGameElementsResultVM
    {
        public int SoundQuestId { get; set; }

        public int SoundCorrectAnswerId { get; set; }

        public int SoundWrongAnswerId { get; set; }

        public byte[] Img { get; set; } = default!;
    }
}
