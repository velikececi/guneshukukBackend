﻿using AutoMapper;
using guneshukuk.BusinessLayer.Abstract;
using guneshukuk.EntityLayer.Dtos.Booking;
using guneshukuk.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace guneshukuk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }
        [HttpGet("GetBookingById")]
        public IActionResult GetArticleById(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);   
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok();
        }
    }
}