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
    public class EfBlogDal : EfEntityRepositoryBase<Blog, CarRentalDbContext>, IBlogDal
    {
        public List<UserForBlogDto> UserForBlogDtos(Expression<Func<UserForBlogDto, bool>> filter = null)
        {
            using (var context = new CarRentalDbContext())
            {
                 var result = from bl in context.Blogs
                              join u in context.Users
                              on bl.UserId equals u.Id
                              select new UserForBlogDto
                              {
                                 Id = bl.Id,
                                 UserFullName = $"{u.FirstName } {u.LastName}",
                                 Title = bl.Title,
                                 Description = bl.Description,
                                 Date = bl.Date,
                                 ImageUrl = bl.ImageUrl
                              };
                 return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}