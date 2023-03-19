using Entities;

namespace POC_API.Repository.IRepository
{
    public interface ICompanyRepository
    {
        Task<bool> Create(Company user);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> UpdateCompany(Company company);
        Task<Company> GetCompanyById(int Id);
    }
}
