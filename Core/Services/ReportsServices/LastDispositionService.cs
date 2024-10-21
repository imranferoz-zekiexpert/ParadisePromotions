using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Services.ReportsServices
{
    public class LastDispositionService : ILastDispositionService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public LastDispositionService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateLastDisposition(LastDisposition lastDisposition)
        {
            if (lastDisposition != null)
            {

                await _unitOfWork.LastDisposition.Insert(lastDisposition);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteLastDisposition(int id)
        {
            if (id > 0)
            {
                var lastDisposition = await _unitOfWork.LastDisposition.GetById(id);
                if (lastDisposition != null)
                {
                    _unitOfWork.LastDisposition.Delete(lastDisposition);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<LastDisposition>> GetAllLastDisposition()
        {
            var lastDispositions = await _unitOfWork.LastDisposition.GetAll();
            return lastDispositions; ;
        }

        public async Task<LastDisposition> GetLastDispositionById(int id)
        {
            if (id > 0)
            {
                var lastDisposition = await _unitOfWork.LastDisposition.GetById(id);
                if (lastDisposition != null)
                {
                    return lastDisposition;
                }
            }
            return null;
        }

        public async Task<bool> UpdateLastDisposition(LastDisposition lastDisposition)
        {
            if (lastDisposition == null)
            {
                return false;
            }

            // Fetch the existing lastDisposition item by CustomerID (assuming CustomerID is the unique identifier)
            var existingLastDisposition = await _unitOfWork.LastDisposition.GetById(lastDisposition.Id);
            if (existingLastDisposition == null)
            {
                return false;
            }

            // Update the properties of the existing lastDisposition with the new values
            existingLastDisposition.CustomerID = lastDisposition.CustomerID;
            existingLastDisposition.MaxOfNoteHistoryID = lastDisposition.MaxOfNoteHistoryID;
            existingLastDisposition.Disposition = lastDisposition.Disposition;
            existingLastDisposition.NoteDateTime = lastDisposition.NoteDateTime;
            existingLastDisposition.SortOrder = lastDisposition.SortOrder;

            // Perform the update in the database
            _unitOfWork.LastDisposition.Update(existingLastDisposition);

            // Save the changes
            var result =  _unitOfWork.Save();
            return result > 0;
        }


    }
}
