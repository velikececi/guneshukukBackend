using guneshukuk.WebUI.Dtos.ConsultancyDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
    public class ConsultancyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultancyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Consultancy/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultConsultancyDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateConsultancy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsultancy(CreateConsultancyDto createConsultancyDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createConsultancyDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/Consultancy/CreateConsultancy", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> DeleteConsultancy(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/Consultancy/DeleteConsultancy/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateConsultancy(int Id)
        {
            HttpClient httpclient = _httpClientFactory.CreateClient();
            var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/Consultancy/GetConsultancyById?Id={Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateConsultancyDto>(jsonData);

                return View(value);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateConsultancy(UpdateConsultancyDto updateConsultancyDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateConsultancyDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/Consultancy/UpdateConsultancy", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
