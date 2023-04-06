using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTestimonialDal : EfEntityRepositoryBase<Testimonial, CarRentalDbContext>, ITestimonialDal
    {
        public List<CustomerTestimonialDto> GetCustomerTestimonialDtos(Expression<Func<CustomerTestimonialDto, bool>> filter = null)
        {
            using (var context = new CarRentalDbContext())
            {
                  var result = from tst in context.Testimonials
                               join cs in context.Customers
                               on tst.CustomerId equals cs.Id
                               join us in context.Users
                               on cs.UserId equals us.Id
                               select new CustomerTestimonialDto
                               {
                                    Id = tst.Id,
                                    Client = $"{us.FirstName} {us.LastName}",
                                    Comment = tst.Comment,
                                    Status = tst.Status
                               };

                   return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}