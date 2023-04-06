using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IModelDal:IEntityRepository<Model>
    {
        List<ModelFeatureDto> GetModelFeatureDtos(Expression<Func<ModelFeatureDto, bool>> filter = null);
        ModelFeatureDto GetModelFeatureDto(Expression<Func<ModelFeatureDto, bool>> filter);
    }
}