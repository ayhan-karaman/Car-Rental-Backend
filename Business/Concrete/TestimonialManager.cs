using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        [SecuredOperation("user")]
        public IResult Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
            return new SuccessResult("Yorumunuz eklendi.");
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            var testimonials = _testimonialDal.GetAll();
            return testimonials.Count > 0 ? new SuccessDataResult<List<Testimonial>>(testimonials)
            : new ErrorDataResult<List<Testimonial>>("Müşteri yorumu bulunamadı!");
        }

        public IDataResult<List<CustomerTestimonialDto>> GetAllCustomerTestimonailDtos()
        {
            var testimonials = _testimonialDal.GetCustomerTestimonialDtos().Take(3).ToList();
            return testimonials.Count > 0 ? new SuccessDataResult<List<CustomerTestimonialDto>>(testimonials)
            : new ErrorDataResult<List<CustomerTestimonialDto>>("Müşteri yorumu bulunamadı!");
        }

        [SecuredOperation("user")]
        public IResult Update(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
            return new SuccessResult();
        }
    }
}