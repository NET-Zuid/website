using System.ComponentModel.DataAnnotations;

namespace DNZ.Common.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "This field is required")]
        public string Message { get; set; }
    }
}
