using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace POC_WEB.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SupplierController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult ManageSuppliers()
        {
            return View();
        }
        public IActionResult SearchSupplier()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> CreateUpdateSupplier(CompanyDTO companyDTO)
        {

            try
            {
                if (companyDTO.Id == 0)
                {
                    ////////////////////////////////////////////////////

                    var request = new HttpRequestMessage(HttpMethod.Post, SD.CompanyAPIPath + "CreateCompany/");

                    request.Content = new StringContent(JsonConvert.SerializeObject(companyDTO), Encoding.UTF8, "application/json");
                    var client = _clientFactory.CreateClient();
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return Json(new { valid = true, message = "You have succesfully added a Suppliers", value = 1 });
                    }

                    return Json(new { valid = false, message = "Something went wrong when saving, please try again" });
                }
                else
                {
                    var request = new HttpRequestMessage(HttpMethod.Put, SD.CompanyAPIPath + "UpdateCompany/");

                    request.Content = new StringContent(JsonConvert.SerializeObject(companyDTO), Encoding.UTF8, "application/json");
                    var client = _clientFactory.CreateClient();
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return Json(new { valid = true, message = "You have succesfully updated Suppliers", value = 1 });
                    }

                    return Json(new { valid = false, message = "Something went wrong when saving, please try again" });
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpGet]
        public async Task<JsonResult> GetAllSupliers()
        {
            IEnumerable<Company> obj = null;
            var request = new HttpRequestMessage(HttpMethod.Get, SD.CompanyAPIPath + "GetAllCompanies");

            var client = _clientFactory.CreateClient();
            HttpResponseMessage apiResponse = await client.SendAsync(request);

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await apiResponse.Content.ReadAsStringAsync();

                obj = JsonConvert.DeserializeObject<IEnumerable<Company>>(jsonString);
            }

            return Json(new { data = obj });
        }
        [HttpGet]
        public async Task<JsonResult> GetSupplierById(int Id)
        {
            Company obj = null;
            var request = new HttpRequestMessage(HttpMethod.Get, SD.CompanyAPIPath + "GetCompanyById/" + Id);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage apiResponse = await client.SendAsync(request);

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await apiResponse.Content.ReadAsStringAsync();

                obj = JsonConvert.DeserializeObject<Company>(jsonString);
            }

            return Json(new { data = obj });
        }
    }

}
