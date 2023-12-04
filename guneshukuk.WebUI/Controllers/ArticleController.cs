using guneshukuk.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace guneshukuk.WebUI.Controllers
{
	
	public class ArticleController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ArticleController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		
		public async Task<IActionResult> Index()
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Article/GetAll");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
				return View(values);
			}
			return View();
		}

        [HttpGet]
		[AllowAnonymous]
        public async Task<IActionResult> UIndex()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Article/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateArticle()
		{ 
			return View(); 
		}

		[HttpPost]
		public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
		{
			var httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createArticleDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/Article/CreateArticle", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteArticle(int id)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var responseMessage = await httpClient.DeleteAsync($"https://localhost:7183/api/Article/DeleteArticle/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> UpdateArticle(int Id)
		{
			HttpClient httpclient = _httpClientFactory.CreateClient();
			var responseMessage = await httpclient.GetAsync($"https://localhost:7183/api/Article/GetArticleById?Id={Id}");



			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateArticleDto>(jsonData);

				return View(value);
			}
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> UpdateArticle(UpdateArticleDto updateArticleDto)
		{
			HttpClient httpClient = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateArticleDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/Article/UpdateArticle", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
