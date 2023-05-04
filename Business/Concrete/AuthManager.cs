using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.ValidationAspects;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelpler;
        private readonly IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelpler)
        {
            _userService = userService;
            _tokenHelpler = tokenHelpler;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetOperationClaims(user);
            var accessToken = _tokenHelpler.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }

        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmailOrUserName(userForLoginDto.EmailOrUserName);
            if(!userToCheck.Success)
                return new ErrorDataResult<User>(userToCheck.Message);
             if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
                return new ErrorDataResult<User>("Lütfen bilgilerinizi kontrol ediniz!");


             return new SuccessDataResult<User>(userToCheck.Data, "Giriş yapıldı.");
        }


        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result =  _userService.Add(user);
            return result.Success ? new SuccessDataResult<User>(user, result.Message)
            : new ErrorDataResult<User>(result.Message);

        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}