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
    public class EfModelDal : EfEntityRepositoryBase<Model, CarRentalDbContext>, IModelDal
    {
     
        public List<ModelFeatureDto> GetModelFeatureDtos(Expression<Func<ModelFeatureDto, bool>> filter = null)
        {
            using (var context = new CarRentalDbContext())
            {
                var result = GetQuery(context);

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public ModelFeatureDto GetModelFeatureDto(Expression<Func<ModelFeatureDto, bool>> filter)
        {
            using (var context = new CarRentalDbContext())
            {
                var result = GetQuery(context).Where(filter).FirstOrDefault();
                return result;
            }
        }


        private static IQueryable<ModelFeatureDto> GetQuery(CarRentalDbContext context)
        {
            return from mdl in context.Models
                   join clr in context.Colors
                   on mdl.ColorId equals clr.Id
                   join brnd in context.Brands
                   on mdl.BrandId equals brnd.Id

                   select new ModelFeatureDto
                   {
                       ModelId = mdl.Id,
                       ModelName = mdl.ModelName,
                       BrandName = brnd.Name,
                       ColorName = clr.Name,
                       DailyPrice = mdl.DailyPrice,
                       GearType = mdl.GearType,
                       FuelType = mdl.FuelType,
                       Description = mdl.Description,
                       IsAirConditioner = mdl.IsAirConditioner,
                       IsGps = mdl.IsGps,
                       ModelImageUrls = context.ModelImages.Where(x => x.ModelId == mdl.Id).ToList().Count > 0
                         ? context.ModelImages.Where(x => x.ModelId == mdl.Id).Select(x => x.ImageUrl).ToList()
                         : new List<string> { "/ModelImages/default.png" }
                   };
        }

        
    }
}