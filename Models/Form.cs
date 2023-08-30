using ChipsForm.Models.ReadOnly;

namespace ChipsForm.Models
{
    public class Form
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string ReferredToUs { get; set; }
        public string SelfiePhoto { get; set; }
        public string Reference { get; set; }
        public string UploadFrontID { get; set; }
        public string UploadBackID { get; set; }

        public Form(FormDTO formDTO)
        {
            Id = formDTO.Id;
            Name= formDTO.Name;
            PhoneNumber= formDTO.PhoneNumber;
            BirthDate= formDTO.BirthDate;
            Email= formDTO.Email;
            HomeAddress= formDTO.HomeAddress;
            ReferredToUs= formDTO.ReferredToUs;
            SelfiePhoto= formDTO.SelfiePhoto;
            Reference= formDTO.Reference;
            UploadFrontID = formDTO.UploadFrontID;
            UploadBackID= formDTO.UploadBackID;
                
        }
        public Form()
        {

        }
    }
}
