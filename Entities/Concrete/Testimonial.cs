using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Testimonial : IEntity
    {
         public int Id { get; set; }
         public int CustomerId { get; set; }
         public string Comment { get; set; }
         public bool Status { get; set; }
    }
}