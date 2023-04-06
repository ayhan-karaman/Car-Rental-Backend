using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
        IDataResult<List<Model>> GetAllModels();

        IDataResult<List<ModelFeatureDto>> GetAllModelFeatureDtos();
        IDataResult<Model> GetById(int id);
        IDataResult<ModelFeatureDto> GetByModelId(int modelId);
    }
}