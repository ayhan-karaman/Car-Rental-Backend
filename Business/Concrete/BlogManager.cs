using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.ValidationAspects;
using Core.Utilities.Results;
using Core.Utilities.Upload;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        [SecuredOperation("admin,super_admin")]
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog, IFormFile file)
        {
            if(file is not null)
            {
                 var uploadFile = UploadHelper.AddFile(new FileFeature{
                Files = file,
                FolderName= "BlogImages/",
                ExtensionType = ExtensionType.Image
            });
                if(uploadFile.Success)
                {
                    blog.ImageUrl = uploadFile.Data;
                    blog.Date = DateTime.UtcNow;
                    _blogDal.Add(blog);
                    return new SuccessResult("Blog yazısı resim ile birlikte eklendi");
                }
                return new ErrorResult(uploadFile.Message);
            }
            _blogDal.Add(blog);
            return new SuccessResult("Blog yazısı kayıt edildi resim eklenmedi");
             
        }

        public IDataResult<List<Blog>> GetAll()
        {
            var blogs = _blogDal.GetAll();
            return blogs.Count > 0 
            ? new SuccessDataResult<List<Blog>>(blogs)
            : new ErrorDataResult<List<Blog>>();
        }

        public IDataResult<UserForBlogDto> GetByIdUserForBlogDtos(int id)
        {
            var blog = _blogDal.UserForBlogDtos().SingleOrDefault(x => x.Id == id);
            return blog != null
            ? new SuccessDataResult<UserForBlogDto>(blog)
            : new ErrorDataResult<UserForBlogDto>();
        }

        public IDataResult<List<UserForBlogDto>> GetUserForBlogDtos()
        {
            var blogs = _blogDal.UserForBlogDtos().OrderByDescending(x => x.Date).Take(3).ToList();
            return blogs.Count > 0 
            ? new SuccessDataResult<List<UserForBlogDto>>(blogs)
            : new ErrorDataResult<List<UserForBlogDto>>();
        }

        public IResult Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}