using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class CustomerTestimonialDto:IDTO
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string? ClientImage { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }

    }
}