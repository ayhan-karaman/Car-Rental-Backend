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
    public interface IBlogDal: IEntityRepository<Blog>
    {
          List<UserForBlogDto> UserForBlogDtos(Expression<Func<UserForBlogDto, bool>> filter = null);
    }
}