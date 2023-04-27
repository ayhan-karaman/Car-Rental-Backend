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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDbContext>, IRentalDal
    {
        public List<CustomerRentalDtos> GetCustomerRentalDtos(Expression<Func<CustomerRentalDtos, bool>> filter = null)
        {
            
            using (var context = new CarRentalDbContext())
            {
                
                var result = from rental in context.Rentals
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join  user in context.Users 
                             on  customer.UserId equals user.Id
                             join model in context.Models 
                             on rental.ModelId equals model.Id
                             join brand in context.Brands
                             on model.BrandId equals brand.Id
                             select new CustomerRentalDtos
                             {
                                 FullName = user.FirstName + " " + user.LastName,
                                 ModelName = brand.Name + " " + model.ModelName,
                                 DailyPrice = model.DailyPrice,
                                 RentStartDate = rental.RentStartDate,
                                 TotalPrice = model.DailyPrice * rental.TotalRentDay,
                                 RentEndDate = rental.RentEndDate,
                                 ReturnDate = rental.ReturnDate,
                                 TotalRentDay =rental.TotalRentDay,
                                 CustomerId = customer.Id,
                                 ImageUrl = !String.IsNullOrEmpty(context.ModelImages.FirstOrDefault(x => x.ModelId == model.Id).ImageUrl) ? 
                                 context.ModelImages.FirstOrDefault(x => x.ModelId == model.Id).ImageUrl : "/ModelImages/default.png"
                             };

                   
                    return filter == null ?  result.ToList() : result.Where(filter).ToList();
            }
        }

            
    }
}