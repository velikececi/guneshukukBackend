using guneshukuk.WebUI.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
	public class SocialMediaController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SocialMediaController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/SocialMedia/GetAll");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/SocialMedia/CreateSocialMedia", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/SocialMedia/DeleteSocialMedia/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> UpdateSocialMedia(int Id)
		{
			HttpClient httpclient = _httpClientFactory.CreateClient();
			var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/SocialMedia/GetSocialMediaById?Id={Id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);

				return View(value);
			}
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/SocialMedia/UpdateSocialMedia", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
