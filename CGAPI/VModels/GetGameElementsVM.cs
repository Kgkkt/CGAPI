namespace CGAPI.VModels
{
    public class GetGameElementsVM
    {
        public int PlayListId { get; set; }

        public List<int> CurrentGameElementIds { get; set; } = default!;

        public int Count { get; set; }

    }
}
