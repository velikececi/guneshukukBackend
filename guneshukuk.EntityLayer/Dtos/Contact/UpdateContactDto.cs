﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.EntityLayer.Dtos.Contact
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}