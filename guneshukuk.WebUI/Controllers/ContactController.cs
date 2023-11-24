using guneshukuk.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Contact/GetAll");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/Contact/CreateContact", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public async Task<IActionResult> DeleteContact(int id)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/Contact/DeleteContact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> UpdateContact(int Id)
		{
			HttpClient httpclient = _httpClientFactory.CreateClient();
			var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/Contact/GetContactById?Id={Id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);

				return View(value);
			}
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/Contact/UpdateContact", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
