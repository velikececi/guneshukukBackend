﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.WebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}