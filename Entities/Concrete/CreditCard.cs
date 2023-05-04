using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool State { get; set; }

    }
}