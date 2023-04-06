using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult("Araç modeli eklendi.");
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult("Araç modeli silindi.");
        }

        public IDataResult<List<ModelFeatureDto>> GetAllModelFeatureDtos()
        {
            var modelFeatures = _modelDal.GetModelFeatureDtos();
           
            return modelFeatures.Count > 0 ? 
            new SuccessDataResult<List<ModelFeatureDto>>(modelFeatures, "Araç modelleri listelendi.")
            : new ErrorDataResult<List<ModelFeatureDto>>("Araç modeli bulunamadı!");
        }

        public IDataResult<List<Model>> GetAllModels()
        {
            var models = _modelDal.GetAll();
            return models.Count > 0 ? new SuccessDataResult<List<Model>>(models, "Araç modelleri listelendi.")
            : new ErrorDataResult<List<Model>>("Araç modeli bulunamadı!");
        }

        public IDataResult<Model> GetById(int id)
        {
            var model = _modelDal.Get(x => x.Id == id);
            return model is not null ? new SuccessDataResult<Model>(model, "Aranan araç modeli gösterildi.")
            : new ErrorDataResult<Model>("Aranan araç modeli bulunamadı!");
        }

        public IDataResult<ModelFeatureDto> GetByModelId(int modelId)
        {
            var modelFeatureDto = _modelDal.GetModelFeatureDto(x => x.ModelId == modelId);
            return modelFeatureDto is not null ? new SuccessDataResult<ModelFeatureDto>(modelFeatureDto, "Aranan araç modeli gösterildi.")
            : new ErrorDataResult<ModelFeatureDto>("Aranan araç modeli bulunamadı!");
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult("Araç modeli güncellendi.");
        }
    }
}