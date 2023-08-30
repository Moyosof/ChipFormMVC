using ChipsForm.Infrastructure.Interface;
using ChipsForm.Models;
using ChipsForm.Models.DTO;
using ChipsForm.Models.ReadOnly;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace ChipsForm.Controllers
{
    public class FormController : Controller
    {
        protected ResponseDto _response;
        private readonly IFormService _formService;

        public FormController(IFormService formField)
        {
            _formService = formField;
            this._response = new ResponseDto();
        }
        public async Task<IActionResult> FormIndex()
        {
            try
            {
                var forms = await _formService.GetAllDetail();
                //var formDto = forms.Select(form => new FormDTO
                //{
                //    Name = form.Name,
                //    PhoneNumber= form.PhoneNumber,
                //    BirthDate= form.BirthDate,
                //    Email  = form.Email,
                //    HomeAddress= form.HomeAddress,
                //    ReferredToUs= form.ReferredToUs,
                //    SelfiePhoto= form.SelfiePhoto,
                //    Reference = form.Reference,
                //    UploadFrontID= form.UploadFrontID,
                //    UploadBackID= form.UploadBackID,
                //}).ToList();

                return View(forms);
                //List<FormDTO> form = new();
                //var result = await _formService.GetAllDetail();
                //if (result != null)
                //{
                //    form = JsonConvert.DeserializeObject<List<FormDTO>>(Convert.ToString(result));
                //}
                //return View(result);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading form data.";
                return View(new List<FormDTO>());
            }
       
           //List<FormDTO> form = new();
            //var result = await _formService.GetAllDetail();
            //if (result != null)
            //{
            //    form = JsonConvert.DeserializeObject<List<FormDTO>>(Convert.ToString(result));

            //}
            //string baseUrl = "https://localhost:5200";
            //foreach (var item in form)
            //{
            //    item.SelfiePhoto = $"{baseUrl}/FormImages/selfie/{item.SelfiePhoto}";
            //    item.UploadFrontID = $"{baseUrl}/FormImages/uploadFront/{form.UploadFrontID}";
            //    item.UploadBackID = $"{baseUrl}/FormImages/{item.UploadBackID}";
            //}
            //return View(form);
           
        }
        public IActionResult FormCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormCreate( FormDto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var response = await _formService.AddEmploymentField(model);
                if (response != null)
                {
                    return RedirectToAction(nameof(FormSuccess));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing the form.");
                return View(model);
            }

            return View(model);

            //if (ModelState.IsValid)
            //{
            //    var response = await _formService.AddEmploymentField(model);
            //    if (response != null)
            //    {
            //        return RedirectToAction(nameof(FormSuccess));
            //    }
            //}

            //return View(model);
        }

        public IActionResult FormSuccess()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FormDelete(Guid id)
        {
            var form =await _formService.GetbyId(id);
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> FormDelete(Guid id, Form model)
        {
            //var form = await _formService.GetbyId(id);
            var deleteForm = await _formService.DeleteForm(id, model);
            if (deleteForm != null)
            {
                    return RedirectToAction(nameof(FormIndex));

            }
            return View();
        }
    }
}



//[Bind("Id, Name, PhoneNumber, BirthDate, Email, HomeAddress, ReferredToUs, Selfie, Reference, UploadFront, UploadBack")]