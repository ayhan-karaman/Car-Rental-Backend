using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Upload;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

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

        [SecuredOperation("user")]
        public IDataResult<UserDetailDto> GetByEmailUserDetailDto(string value)
        {
             var user = _userDal.GetUserDetailDto(x => x.Email == value || x.UserName == value);


             user.ImageUrl =  String.IsNullOrEmpty(user.ImageUrl) ?  "/UserImages/avatar.png" : user.ImageUrl;


            return user != null ? new SuccessDataResult<UserDetailDto>(user) 
            : new ErrorDataResult<UserDetailDto>("Kullanıcıc bulunamadı");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        [SecuredOperation("user")]
        public IResult UpdateUserProfile(UserForUpdateDto userForUpdateDto)
        {
            var user = GetByEmail(userForUpdateDto.Email);
            if(user.Success)
            {
                  
                  var imageResult = "";
                  if(userForUpdateDto.File != null) 
                  {
                         
                    imageResult = user.Data.ImageUrl == null 
                    ? UploadHelper.AddFile(new FileFeature{Files = userForUpdateDto.File, FolderName = "UserImages/", ExtensionType = ExtensionType.Image}).Data
                    : UploadHelper.UpdatedFile(new FileFeature{Files = userForUpdateDto.File, FolderName = user.Data.ImageUrl, ExtensionType = ExtensionType.Image}).Data;
                  
                  }
                  
                  user.Data.FirstName = userForUpdateDto.FirstName;
                  user.Data.LastName = userForUpdateDto.LastName;
                  user.Data.UserName = userForUpdateDto.UserName;
                  user.Data.ImageUrl = String.IsNullOrEmpty(imageResult) ? user.Data.ImageUrl : imageResult;
                  
                  var result = Update(user.Data);
                  return result.Success 
                  ? new SuccessResult("Profile bilgileriniz güncellendi") 
                  : new ErrorResult("Bir hata oluştu");
            }
            return new ErrorResult(user.Message);
        }

        [SecuredOperation("user")]
        public IResult UpdateUserPassword(UpdateUserPasswordDto updateUserPassword)
        {
            var user = GetByEmail(updateUserPassword.Email);
            if(user.Success)
            {
                 bool empty = !string.IsNullOrEmpty(updateUserPassword.NewPassword) && !string.IsNullOrEmpty(updateUserPassword.ConfirmPassword);
                 bool verify = HashingHelper.VerifyPasswordHash(updateUserPassword.CurrentPassword, user.Data.PasswordHash, user.Data.PasswordSalt)
                 && updateUserPassword.NewPassword == updateUserPassword.ConfirmPassword;
                 if(!verify || !empty)
                    return new ErrorResult("Parola bilgilerinizi kontrol ediniz");
            
                 byte[] passwordHash, passwordSalt;
                 HashingHelper.CreatePasswordHash(updateUserPassword.NewPassword, out passwordHash, out passwordSalt);
                 user.Data.PasswordHash = passwordHash;
                 user.Data.PasswordSalt = passwordSalt;
                var result = Update(user.Data);
                return result.Success ? new SuccessResult("Parolanız güncellendi") : new ErrorResult("Bir hata oluştu.");
            }
            return new ErrorResult("Kullanıcı Bulunamadı");
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