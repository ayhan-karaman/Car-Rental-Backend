using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class ModelFeatureDto :IDTO
    {
        public int ModelId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
        public string GearType { get; set; }
        public string FuelType { get; set; }
        public string Description { get; set; }
        public bool IsAirConditioner { get; set; }
        public bool IsGps { get; set; }
        public List<string> ModelImageUrls { get; set; }
    }
}