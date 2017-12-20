using System.ComponentModel.DataAnnotations;

namespace Rb2Test.Api.ViewModels
{
    public class TalkViewModel
    {
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Title should accept only letters and spaces")]
        public string Title { get; set; }
        public ushort Length { get; set; }
    }
}