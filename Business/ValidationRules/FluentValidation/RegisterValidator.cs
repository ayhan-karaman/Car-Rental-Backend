using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen kullanıcı adınızı veya email adresinizi giriniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen geçerli bir email adresi giriniz");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen adınızı yazınız");
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Adınız en az 3 karakterden oluşmalıdır");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyadınızı yazınız");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyadınızı en az 3 karakterden oluşmalıdır");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifreniz minimum beş karater olmalıdır");
            RuleFor(x => x.Password).Must(InCharacter).WithMessage("Parolanız küçük harf, büyük harf, sayı ve özel karakter içermelidir.");
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