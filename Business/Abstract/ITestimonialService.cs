using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IResult Add(Testimonial testimonial);
        IResult Update(Testimonial testimonial);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<List<CustomerTestimonialDto>> GetAllCustomerTestimonailDtos();
    }
}