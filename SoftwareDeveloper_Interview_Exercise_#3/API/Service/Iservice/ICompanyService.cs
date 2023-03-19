using Entities;
using Entities.DTOs;

namespace POC_API.Service.Iservice
{
    public interface ICompanyService
    {
        Task<bool> Create(CompanyDTO companyDTO);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> UpdateCompany(CompanyDTO company);
        Task<Company> GetCompanyById(int Id);
    }
}
