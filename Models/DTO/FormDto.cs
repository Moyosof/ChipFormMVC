using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChipsForm.Models.DTO
{
    public class FormDto
    {

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public string BirthDate { get; set; }

        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        [DisplayName("How were you referred to us?")]
        public string ReferredToUs { get; set; }

        [DisplayName("Selfie")]
        [Required]
        public IFormFile Selfie { get; set; }

        [DisplayName("Reference")]
        public string Reference { get; set; }

        [DisplayName("Upload Front")]
        [Required]
        public IFormFile UploadFront { get; set; }

        [DisplayName("Upload Back")]
        [Required]
        public IFormFile UploadBack { get; set; }
    }
}
