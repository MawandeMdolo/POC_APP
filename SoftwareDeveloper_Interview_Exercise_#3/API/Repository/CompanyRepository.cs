using POC_API.Data;
using POC_API.Repository.IRepository;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;


namespace POC_API.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _repo;
        public CompanyRepository(ApplicationDbContext repo)
        {
            _repo = repo;
        }
        public async Task<bool> Create(Company company)
        {
            bool results = false;
            try
            {

                await _repo.Company.AddAsync(company);
                await Save();
                results = true;

            }
            catch (Exception)
            {

                throw;
            }
            return results;
        }
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                return await _repo.Company.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Company> GetCompanyById(int Id)
        {

            try
            {
                return await _repo.Company.AsNoTracking().Where(p => p.Id == Id).SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Company> UpdateCompany(Company company)
        {
            try
            {
   

                _repo.Company.Update(company);
                await Save();

                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Save()
        {
            bool successfull = false;
            try
            {
                await _repo.SaveChangesAsync();

                successfull = true;
            }
            catch (OptimisticConcurrencyException exc)
            {
                //TODO: Error handling;
            }
            catch (UpdateException exc)
            {
                //TODO: Error handling;
            }
            catch (Exception exc)
            {
                //TODO: Error handling;
            }

            return successfull;
        }
    }
}
