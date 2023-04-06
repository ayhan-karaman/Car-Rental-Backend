using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ICustomerService _customerService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserManager(
            IUserDal userDal,
            ICustomerService customerService,
            IOperationClaimService operationClaimService,
            IUserOperationClaimService userOperationClaimService
            )
        {
            _userDal = userDal;
            _customerService = customerService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IResult Add(User user)
        {
            var result = BusinessRules.Run(CheckIsEmailAndUserName(user));
            if(result != null)
                return result;
            _userDal.Add(user);
            CreatedCustomer(user.Id);
            CreatedUserOperationClaim(user.Id);
            return new SuccessResult("Kullanıcı kayıt edildi");
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var user = _userDal.Get(x => x.Email == email);
            return user is not null ? new SuccessDataResult<User>(user)
            : new ErrorDataResult<User>("Kullanıcı bulunamadı");
        }

        public IDataResult<User> GetByEmailOrUserName(string value)
        {
            var user = _userDal.Get(x => x.Email == value || x.UserName == value);
            return user != null ? new SuccessDataResult<User>(user) 
            : new ErrorDataResult<User>("Kullanıcıc bulunamadı");
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            var user = _userDal.Get(x => x.UserName == userName);
            return user is not null ? new SuccessDataResult<User>(user)
            : new ErrorDataResult<User>("Kullanıcı bulunamadı");
        }

        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            var claims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIsEmailAndUserName(User user)
        {
            var getUser = _userDal.Get(x => x.Email == user.Email || x.UserName == user.UserName);
            if(getUser is not null)
                return new ErrorResult("Kullanıcı daha kayıt edilmiş.");
            return new SuccessResult();
        }

        private IResult CreatedUserOperationClaim(int userId)
        {
                var operationClaim = _operationClaimService.GetByName("user").Data;
                if(userId > 0 && operationClaim is not null)
                {
                     var result =  _userOperationClaimService.Add(new UserOperationClaim{
                            UserId = userId,
                            OperationClaimId = operationClaim.Id
                     });

                     return result.Success ? new SuccessResult() : new ErrorResult();
                }
                return new ErrorResult();
        }
        private IResult CreatedCustomer(int userId)
        {
              var result =   _customerService.Add(new Customer{
                UserId= userId,
                CustomerNumber = ""
            });
            return result.Success ? new SuccessResult() : new ErrorResult();
        }
    }
}