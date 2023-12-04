using guneshukuk.WebUI.Dtos.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using System.Security.Policy;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task< IActionResult> Index()
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Booking/GetAll");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}

        [HttpGet]
		[AllowAnonymous]
        public async Task<IActionResult> UIndex()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Booking/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateBooking()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
		{
			
			HttpClient httpClient = _httpClientFactory.CreateClient();		
			var jsonData = JsonConvert.SerializeObject(createBookingDto);			
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/Booking/CreateBooking", content);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		public async Task<IActionResult> DeleteBooking(int id)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/Booking/DeleteBooking/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> UpdateBooking(int Id)
		{
			HttpClient httpclient = _httpClientFactory.CreateClient();
			var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/Booking/GetBookingById?Id={Id}");



			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);

				return View(value);
			}
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/Booking/UpdateBooking", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
