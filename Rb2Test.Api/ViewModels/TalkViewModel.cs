using System.ComponentModel.DataAnnotations;

namespace Rb2Test.Api.ViewModels
{
    public class TalkViewModel
    {
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Title should accept only letters")]
        public string Title { get; set; }
        public ushort Length { get; set; }
    }
}