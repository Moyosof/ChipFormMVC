using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChipsForm.Models.ReadOnly
{
    public class FormDTO
    {
        public Guid Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public string BirthDate { get; set; }

        [DisplayName("Email Address")]

        public string Email { get; set; }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        [DisplayName("How were you referred to us?")]
        public string ReferredToUs { get; set; }

        [DisplayName("Selfie Photo")]
        public string SelfiePhoto { get; set; }

        [DisplayName("Reference")]
        public string Reference { get; set; }

        [DisplayName("Upload Front ID ")]
        public string UploadFrontID { get; set; }

        [DisplayName("Upload Back ID ")]
        public string UploadBackID { get; set; }

        public FormDTO(Form form)
        {
            Id= form.Id;
            Name= form.Name;
            PhoneNumber= form.PhoneNumber;
            BirthDate= form.BirthDate;
            Email= form.Email;
            HomeAddress= form.HomeAddress;
            ReferredToUs= form.ReferredToUs;
            SelfiePhoto= form.SelfiePhoto;
            Reference= form.Reference;
            UploadFrontID= form.UploadFrontID;
            UploadBackID= form.UploadBackID;

        }
    }
}
