using ChipsForm.Models;
using ChipsForm.Models.DTO;
using Microsoft.AspNetCore.Http;

namespace ChipsForm.Infrastructure.Interface
{
    public interface IFormService
    {
        Task<IEnumerable<Form>> GetAllDetail();
        Task<Form> AddEmploymentField(FormDto formDto);
        Task<Form> GetbyId(Guid id);
        Task<bool> DeleteForm(Guid id, Form form);
    }
}
