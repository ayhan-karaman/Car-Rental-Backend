using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(Blog blog, IFormFile file);
        IResult Update(Blog blog);
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<UserForBlogDto>> GetUserForBlogDtos();
    }
}