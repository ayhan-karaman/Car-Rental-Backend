using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult();
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<OperationClaim> GetByName(string name)
        {
            var operationClaim = _operationClaimDal.Get(x => x.Name == name);
            return operationClaim is not null ? new SuccessDataResult<OperationClaim>(operationClaim)
            : new ErrorDataResult<OperationClaim>();
        }

        public IResult Update(OperationClaim operationClaim)
        {
            throw new NotImplementedException();
        }
    }
}