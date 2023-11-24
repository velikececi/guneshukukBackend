using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.WebUI.Dtos.ConsultancyDtos
{
    public class CreateConsultancyDto
    {
        
        public string ConsultancyTitle { get; set; }
        public string ConsultancyContent { get; set; }
        public string ImageUrl { get; set; }
    }
}
