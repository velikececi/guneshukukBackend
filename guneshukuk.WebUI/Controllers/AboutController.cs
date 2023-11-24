using guneshukuk.WebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/About/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>CreateAbout(CreateAboutDto createAboutDto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/About/CreateAbout", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
       
        public async Task<IActionResult> DeleteAbout(int id)
        {
            HttpClient httpClient= _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/About/DeleteAbout/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateAbout(int Id)
        {
            HttpClient httpclient= _httpClientFactory.CreateClient();
            var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/About/GetAboutById?Id={Id}");
           


			if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
               
                return View(value);                
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var jsonData =  JsonConvert.SerializeObject(updateAboutDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/About/UpdateAbout", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
