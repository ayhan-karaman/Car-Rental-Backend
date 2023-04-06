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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
             if(IsBrandName(brand.Name).Success)
            {
                _brandDal.Add(brand);
                return new SuccessResult("Marka adı eklendi");
            }
            else
                return new ErrorResult("Marka adı daha önce eklenmiş!");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Marka adı silindi");
        }

        public IDataResult<List<Brand>> GetAllBrands()
        {
            var brands = _brandDal.GetAll();
            return brands.Count > 0 ?
             new SuccessDataResult<List<Brand>>(brands, "Markalar listelendi")
             : new ErrorDataResult<List<Brand>>("Marka listesi bulunamadı");
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(x => x.Id == id);
            return brand == null ? 
            new ErrorDataResult<Brand>("Aranan marka adı bulunamadı!")
            : new SuccessDataResult<Brand>(brand, "Markadı gösterildi.");
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult("Marka adı güncellendi");
        }

        private IResult IsBrandName(string brandName)
        {
             var brand = _brandDal.Get(x => x.Name.ToLower() == brandName.ToLower());
            return brand is null ? new SuccessResult()
             : new ErrorResult();
        }
    }
}