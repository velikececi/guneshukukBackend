﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.EntityLayer.Dtos.Consultancy
{
    public class GetConsultancyDto
    {
        public int ConsultancyId { get; set; }
        public string ConsultancyTitle { get; set; }
        public string ConsultancyContent { get; set; }
        public string ImageUrl { get; set; }
    }
}
