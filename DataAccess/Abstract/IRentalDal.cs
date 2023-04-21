using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        public List<CustomerRentalDtos> GetCustomerRentalDtos(Expression<Func<CustomerRentalDtos, bool>> filter=null);
    }
}