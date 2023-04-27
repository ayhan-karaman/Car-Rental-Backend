using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class CustomerRentalDtos:IDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int TotalRentDay { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}