﻿using System.Data.SqlTypes;

namespace guneshukuk.WebUI.Dtos.BookingDtos
{
	public class UpdateBookingDto
	{
		public int BookingId { get; set; }
		public string BookingName { get; set; }
		public string BookingEmail { get; set; }
		public string BookingPhone { get; set; }
		public string BookingMessage { get; set; }
		public DateTime BookingDate { get; set; }
	}
}