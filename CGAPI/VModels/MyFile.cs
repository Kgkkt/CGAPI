

namespace CGAPI.VModels
{
    public class MyGameElement
    {
       
        public string? Txt { get; set; }       
        public List<IFormFile>? Img { get; set; }

        public List<IFormFile>? Quest { get; set; }

        public List<IFormFile>? CorrectAnswer { get; set; }

        public List<IFormFile>? WrongAnswer { get; set; }

    }
}
