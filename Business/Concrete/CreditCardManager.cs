using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult("Kartınız başarı ile kayıt edildi");
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Kartınız silindi");
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            var cards = _creditCardDal.GetAll(x => x.CustomerId == customerId);
            return cards.Count > 0 ? new SuccessDataResult<List<CreditCard>>(cards) : 
            new ErrorDataResult<List<CreditCard>>("Kart bulunamadı.");
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult("Kartınız güncellendi");
        }
    }
}