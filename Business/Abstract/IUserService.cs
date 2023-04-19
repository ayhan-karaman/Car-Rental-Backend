using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserDetailDto> GetByEmailUserDetailDto(string value);
        IDataResult<User> GetByEmailOrUserName(string value);
        IDataResult<User> GetByUserName(string userName);
        IResult UpdateUserProfile(UserForUpdateDto userForUpdateDto);
        IResult UpdateUserPassword(UpdateUserPasswordDto updateUserPassword);
        
    }
}