using ChipsForm.Infrastructure.Interface;
using ChipsForm.Models;
using ChipsForm.Models.DTO;
using ChipsForm.Models.ReadOnly;
using ChipsForm.Repository;
using Microsoft.AspNetCore.Http;

namespace ChipsForm.Infrastructure
{
    public class FormService : AbstractMethods, IFormService
    {
        private readonly ILogger<FormService> _logger;
        private readonly IUnitOfWork<Form> _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static string folderName = "FormImages";

        public FormService(IUnitOfWork<Form> unitOfWork, IWebHostEnvironment webHostEnvironment, ILogger<FormService> logger)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<Form> AddEmploymentField(FormDto formDto)
        {
            try
            {
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (formDto.Selfie == null || formDto.UploadFront == null || formDto.UploadBack == null)
                {
                    throw new ArgumentException("Something went wrong, Wahala");
                }

                string selfiePath = await CreateImage(formDto.Selfie, webRootPath, folderName);
                string uploadFront = await CreateImage(formDto.UploadFront, webRootPath, folderName);
                string uploadBack = await CreateImage(formDto.UploadBack, webRootPath, folderName);

                Form field = new Form()
                {
                    Id = new Guid(),
                    Name = formDto.Name,
                    PhoneNumber = formDto.PhoneNumber,
                    BirthDate = formDto.BirthDate,
                    Email = formDto.Email,
                    HomeAddress = formDto.HomeAddress,
                    ReferredToUs = formDto.ReferredToUs,
                    SelfiePhoto = selfiePath,
                    Reference = formDto.Reference,
                    UploadFrontID = uploadFront,
                    UploadBackID = uploadBack
                };
                await _unitOfWork.Repository.Add(field);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Successfull");
                return field;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "error occured in FormDto: {@FormDto}", formDto);
                throw;
            }
            
        }

        public Task<IEnumerable<Form>> GetAllDetail()
        {
            var results = _unitOfWork.Repository.ReadAllQuery().ToList();
            //var webRootPath = _webHostEnvironment.WebRootPath;
            var baseUrl = "https://localhost:44387";

            for (int i = 0; i < results.Count(); i++)
            {
                results[i].SelfiePhoto = $"{baseUrl}/FormImages/{Path.GetFileName(results[i].SelfiePhoto)}";
                results[i].UploadFrontID = $"{baseUrl}/FormImages/{Path.GetFileName(results[i].UploadFrontID)}";
                results[i].UploadBackID = $"{baseUrl}/FormImages/{Path.GetFileName(results[i].UploadBackID)}";

                //results[i].SelfiePhoto = $"{_webHostEnvironment.WebRootPath}/{results[i].SelfiePhoto}";
                //results[i].UploadFrontID = $"{_webHostEnvironment.WebRootPath}/{results[i].UploadFrontID}";
                //results[i].UploadBackID = $"{_webHostEnvironment.WebRootPath}/{results[i].UploadBackID}";

            }
            return Task.FromResult<IEnumerable<Form>>(results);
        }

        public async Task<bool> DeleteForm(Guid id, Form form)
        {
            string webroothPath = _webHostEnvironment.WebRootPath;

            var forms = await _unitOfWork.Repository.ReadSingle(id);
            DeleteImage(webroothPath, folderName);
            if(form != null)
            {
                await _unitOfWork.Repository.Delete(id) ;
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<Form> GetbyId(Guid id)
        {
            var results = await _unitOfWork.Repository.ReadSingle(id);
            var baseUrl = "https://localhost:44387";


            results.SelfiePhoto = $"{baseUrl}/FormImages/{Path.GetFileName(results.SelfiePhoto)}";
            results.UploadFrontID = $"{baseUrl}/FormImages/{Path.GetFileName(results.UploadFrontID)}";
            results.UploadBackID = $"{baseUrl}/FormImages/{Path.GetFileName(results.UploadBackID)}";
            return results;
        }
    }
}
