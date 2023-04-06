using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class ModelImage:IEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string? ImageUrl { get; set; } 
        public DateTime UploadDate { get; set; }

        public Model Model { get; set; }
    }
}