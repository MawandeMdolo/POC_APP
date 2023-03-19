using Autofac.Core;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_API.Service.Iservice;

namespace POC_API.Controllers
{
    [Route("api/v{version:apiVersion}/Companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
            if (companyDTO != null)
            {
                var user = await _companyService.Create(companyDTO);
                if (user)
                {
                    return Ok(StatusCodes.Status200OK);
                }
                else
                {
                    return Ok(StatusCodes.Status400BadRequest);
                }
            }
            return Ok(StatusCodes.Status400BadRequest);
        }
        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult> GetAllCompanies()
        {
            var objList = await _companyService.GetAllCompanies();
            return Ok(objList);
        }
        [HttpGet("GetCompanyById/{Id}")]
        public async Task<ActionResult> GetCompanyById(string Id)
        {
            int id = int.Parse(Id);
            var objList = await _companyService.GetCompanyById(id);

            return Ok(objList);
        }
        [HttpPut("UpdateCompany")]
        public async Task<ActionResult> UpdateCompany([FromBody] CompanyDTO CompanyDTO)
        {
            if (CompanyDTO.Id == 0)
            {
                return BadRequest(new { message = "Error processing update request" });
            }
            var results = await _companyService.UpdateCompany(CompanyDTO);

            if (results != null)
            {
                return StatusCode(StatusCodes.Status200OK, results);
            }
            else
            {
                return BadRequest(new { message = "No changes made" });
            }
        }


    }
}
