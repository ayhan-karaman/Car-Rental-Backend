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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
             if(IsColorName(color.Name).Success)
            {
                  _colorDal.Add(color);
                  return new SuccessResult("Renk adı eklendi");
            }
            else
                return new ErrorResult("Bu renk daha önce eklenmiş");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Ren adı silindi");
        }

        public IDataResult<List<Color>> GetAllColors()
        {
            var colors = _colorDal.GetAll();
            return colors.Count > 0 ? new SuccessDataResult<List<Color>>(colors, "Renk isimleri listelendi")
            : new ErrorDataResult<List<Color>>("Renk ismi bulunamadı!");
        }

        public IDataResult<Color> GetById(int id)
        {
            var color = _colorDal.Get(x => x.Id == id);
            return color is null ? new ErrorDataResult<Color>("Aranan renk adı bulunamadı!")
            : new SuccessDataResult<Color>(color, "Aranan renk adı bulundu"); 
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Renk ismi güncellendi");
        }

        private IResult IsColorName(string colorName)
        {
              var color = _colorDal.Get(x => x.Name.ToLower() == colorName.ToLower());
              return color is null ? new SuccessResult()
              : new ErrorResult();
               
        }
    }
}