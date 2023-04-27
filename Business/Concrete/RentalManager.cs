using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rules = BusinessRules.Run(IsReturnRentDate(rental.ModelId));
            if (rules != null)
                    return rules;
            
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CustomerRentalDtos>> GetAllCustomerId(int customerId)
        {
             var rentals = _rentalDal.GetCustomerRentalDtos(x => x.CustomerId == customerId);
             return rentals.Count > 0 ? new SuccessDataResult<List<CustomerRentalDtos>>(rentals) 
             : new ErrorDataResult<List<CustomerRentalDtos>>("Kiraladığınız araç bulunamadı"); 
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult IsReturnRentDate(int modelId)
        {
             var rental = _rentalDal.Get(x => x.ModelId == modelId);
             if(rental != null)
             {

                  if(rental.ReturnDate == null) 
                    return  new ErrorResult("Bu araç henüz teslim edilmemiş") ;
             }

              return new SuccessResult();
        }
        private int DateDifference(DateTime rentStartDate, DateTime rentEndDate)
            {
                TimeSpan timeSpan = rentEndDate - rentStartDate;
                int remainingDay = (int)timeSpan.Days;
                
                return remainingDay;
            }

        IDataResult<List<CustomerRentalDtos>> IRentalService.GetAll()
        {
            var rentals = _rentalDal.GetCustomerRentalDtos();
             return rentals.Count > 0 ? new SuccessDataResult<List<CustomerRentalDtos>>(rentals) 
             : new ErrorDataResult<List<CustomerRentalDtos>>("Kiralanan araç bulunamadı"); 
        }
    }
}