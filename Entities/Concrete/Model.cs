using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
        public string GearType { get; set; }
        public string FuelType { get; set; }
        public string Description { get; set; }
        public bool IsAirConditioner { get; set; }
        public bool IsGps { get; set; }

        public Brand Brand { get; set; }
        public Color Color { get; set; }

        public List<ModelImage> ModelImages { get; set; }

    }
}