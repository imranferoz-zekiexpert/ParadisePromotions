using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Services.ReportsServices
{
    public class NextCallBackService : INextCallBackService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public NextCallBackService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateNextCallBack(NextCallBack nextCallBack)
        {
            if (nextCallBack != null)
            {
                nextCallBack.CreatedDate = DateTime.Now;
                await _unitOfWork.NextCallBack.Insert(nextCallBack);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteNextCallBack(int id)
        {
            if (id > 0)
            {
                var nextCallBack = await _unitOfWork.NextCallBack.GetById(id);
                if (nextCallBack != null)
                {
                    _unitOfWork.NextCallBack.Delete(nextCallBack);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<NextCallBack>> GetAllNextCallBack()
        {
            var nextCallBacks = await _unitOfWork.NextCallBack.GetAll();
            return nextCallBacks; ;
        }

        public async Task<NextCallBack> GetNextCallBackById(int id)
        {
            if (id > 0)
            {
                var nextCallBack = await _unitOfWork.NextCallBack.GetById(id);
                if (nextCallBack != null)
                {
                    return nextCallBack;
                }
            }
            return null;
        }

        public async Task<bool> UpdateNextCallBack(NextCallBack nextCallBack)
        {
            if (nextCallBack == null || nextCallBack.Id == null)
            {
                return false;
            }

            // Fetch the existing nextCallBack item by Id
            var existingNextCallBack = await _unitOfWork.NextCallBack.GetById(nextCallBack.Id);
            if (existingNextCallBack == null)
            {
                return false;
            }

            // Update the properties of the existing nextCallBack with the new values
            existingNextCallBack.CustomerId = nextCallBack.CustomerId;
            existingNextCallBack.CallBackDateTime = nextCallBack.CallBackDateTime;
            existingNextCallBack.CallDateTime = nextCallBack.CallDateTime;
            existingNextCallBack.Comment = nextCallBack.Comment;
            existingNextCallBack.UpdatedBy = nextCallBack.UpdatedBy;
            existingNextCallBack.UpdatedDate = DateTime.Now;

            // Perform the update in the database
            _unitOfWork.NextCallBack.Update(existingNextCallBack);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }




    }
}
