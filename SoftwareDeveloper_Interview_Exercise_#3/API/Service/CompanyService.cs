using AutoMapper;
using POC_API.Data;
using POC_API.Repository.IRepository;
using POC_API.Service.Iservice;
using Entities;
using Entities.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using POC_API.Service.Iservice;
using System.Data.Entity.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Runtime.InteropServices;

namespace POC_API.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<bool> Create(CompanyDTO companyDTO)
        {
            bool results = false;
            try
            {
                var companyObj = _mapper.Map<Company>(companyDTO);
                var resulst = await _repo.Create(companyObj);
                results = true;
            }
            catch (Exception)
            {

                throw;
            }
            return results;
        }
        public async Task<Company> UpdateCompany(CompanyDTO companyDTO)
        {
            try
            {

                var companyObj = _mapper.Map<Company>(companyDTO);
                var results= await _repo.UpdateCompany(companyObj);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                return _repo.GetAllCompanies();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<Company> GetCompanyById(int Id)
        {
            try
            {
                return _repo.GetCompanyById(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
