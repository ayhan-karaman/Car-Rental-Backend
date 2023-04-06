using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Upload;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ModelImageManager : IModelImageService
    {
        private readonly IModelImageDal _modelImageDal;

        public ModelImageManager(IModelImageDal modelImageDal)
        {
            _modelImageDal = modelImageDal;
        }

        public IResult Add(ModelImage modelImage, IFormFile files)
        {
            var rules = BusinessRules.Run(CheckIfImageLimit(modelImage.ModelId));
            if (rules != null)
                    return rules;
            
            
                 var result = UploadHelper.AddFile(new FileFeature{Files = files, FolderName = "ModelImages/", ExtensionType = ExtensionType.Image});
                 if(result.Success)
                 {
                        modelImage.ImageUrl = result.Data;
                        modelImage.UploadDate =  DateTime.UtcNow;
                        _modelImageDal.Add(modelImage);
                        return new SuccessResult("Resim Eklendi");
                 }
                 return new ErrorResult(result.Message);
            
        }

        public IDataResult<List<ModelImage>> GetAllByImageId(int modelId)
        {
             var images = _modelImageDal.GetAll(x => x.ModelId == modelId);
             if(images.Count > 0)
             {
                 return new SuccessDataResult<List<ModelImage>>(images, "Araç ait resimler listelendi!");
             }
             images.Add(new ModelImage{
                Id = 0,
                ModelId = modelId,
                ImageUrl = "/ModelImages/default.png",
                UploadDate = DateTime.UtcNow
             });
             return new SuccessDataResult<List<ModelImage>>(images);
        }

        public IResult Update(ModelImage modelImage, IFormFile files)
        {
             var getModelImage = _modelImageDal.Get(x => x.Id == modelImage.Id);
             if(getModelImage != null)
             {
                 // coding update
                 var feature = new FileFeature{Files = files, FolderName = getModelImage.ImageUrl, ExtensionType = ExtensionType.Image};
                 var result = UploadHelper.UpdatedFile(feature);
                 if(result.Success)
                 {
                    getModelImage.ImageUrl = result.Data;
                    getModelImage.ModelId = getModelImage.ModelId;
                    getModelImage.UploadDate = DateTime.UtcNow;
                    _modelImageDal.Update(getModelImage);

                    return new SuccessResult("Resim Güncellendi");
                 }
                 return new ErrorResult(result.Message);
             }
             return new ErrorResult("Araç resim bilgisi bulunamadı!");
        }


        private IResult CheckIfImageLimit(int modelId)
        {
            var images = _modelImageDal.GetAll(x => x.ModelId == modelId);
            return images.Count  >= 5 ? new ErrorResult("Bu araç için resim ekleme limitine ulaşıldı!") : new SuccessResult();
        }
    }
}