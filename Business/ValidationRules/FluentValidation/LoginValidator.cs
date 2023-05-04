using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator:AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı veya email adresinizi giriniz");
         
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifreniz minimum beş karater olmalıdır");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre bilgilerinizi giriniz");
            //RuleFor(x => x.Password).Must(InCharacter).WithMessage("");
        }

        private bool InCharacter(string arg)
        {
            bool isUpLetter = false;
            bool isDigit = false;
            bool isSymbol = false;
            foreach (var item in arg)
            {
                isUpLetter = char.IsUpper(item) ? true : isUpLetter;
                isDigit = char.IsDigit(item) ? true :isDigit;
                isSymbol = char.IsLetterOrDigit(item) ? isSymbol : true; 
            }  
            
            if((isUpLetter = true) && (isDigit = true) && (isSymbol = true))
                return true;
            else
                return false;
            
        }
    }
}