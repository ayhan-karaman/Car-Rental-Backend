using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık bilgisi boş bırakılamaz")
            .MinimumLength(4).WithMessage("Başlık minimum 4 karakter içermelidir");


            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklam bilgisi boş bırakılamaz")
            .MinimumLength(25).WithMessage("Açıklama minimum 25 karakter içermelidir.");
         
        }
    }
}