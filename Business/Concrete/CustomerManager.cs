using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
               customer.CustomerNumber = RandomCustomerNumber();
              _customerDal.Add(customer);
              return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
             var customers = _customerDal.GetAll();
             return customers.Count > 0 
             ? new SuccessDataResult<List<Customer>>(customers)
             : new ErrorDataResult<List<Customer>>();
        }

        public IDataResult<Customer> GetById(int id)
        {
            var customer = _customerDal.Get(x => x.Id == id);
            return customer is null 
            ? new ErrorDataResult<Customer>("Müsteri bulunamadı!")
            : new SuccessDataResult<Customer>(customer);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            var customer = _customerDal.Get(x => x.UserId == userId);
            return customer is null 
            ? new ErrorDataResult<Customer>("Müsteri bulunamadı!")
            : new SuccessDataResult<Customer>(customer);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        private string RandomCustomerNumber()
        {
               
               var numText = "";
               for (int i = 0; i < 7; i++)
               {
                    numText += new Random().Next(0, 9);
               }
               return   _customerDal.Get(x => x.CustomerNumber == numText) is not null 
               ? RandomCustomerNumber() : numText;
        }
    }
}