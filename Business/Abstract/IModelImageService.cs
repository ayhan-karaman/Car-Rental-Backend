using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IModelImageService
    {
        IResult Add(ModelImage modelImage, IFormFile files);
        IResult Update(ModelImage modelImage, IFormFile files);
        IDataResult<List<ModelImage>> GetAllByImageId(int modelId);
    }
}