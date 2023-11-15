using AutoMapper;
using guneshukuk.BusinessLayer.Abstract;
using guneshukuk.EntityLayer.Dtos.About;
using guneshukuk.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);  
        }
        [HttpPost] 
        public IActionResult CreateAbout (CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("EKLENDİ");
        }
        [HttpGet("GetAboutById")]
        public IActionResult GetAboutById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteAboutById(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok();
            
        }
        [HttpPut]
        IActionResult UpdateAbout (UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok();
        }
    }
}
