using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class TouchLogService : ITouchLogService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public TouchLogService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateTouchLog(TouchLog touchLog)
        {
            if (touchLog != null)
            {
               
                await _unitOfWork.TouchLog.Insert(touchLog);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTouchLog(int id)
        {
            if (id > 0)
            {
                var touchLog = await _unitOfWork.TouchLog.GetById(id);
                if (touchLog != null)
                {
                    _unitOfWork.TouchLog.Delete(touchLog);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<TouchLog>> GetAllTouchLog()
        {
            var touchLogs = await _unitOfWork.TouchLog.GetAll();
            return touchLogs; ;
        }

        public async Task<TouchLog> GetTouchLogById(int id)
        {
            if (id > 0)
            {
                var touchLog = await _unitOfWork.TouchLog.GetById(id);
                if (touchLog != null)
                {
                    return touchLog;
                }
            }
            return null;
        }

        public async Task<bool> UpdateTouchLog(TouchLog touchLog)
        {
            if (touchLog == null)
            {
                return false;
            }

            var existingTouchLog = await _unitOfWork.TouchLog.GetById(touchLog.TouchLogID);
            if (existingTouchLog == null)
            {
                return false;
            }

            existingTouchLog.Employee = touchLog.Employee;
            existingTouchLog.CustomerID = touchLog.CustomerID;
            existingTouchLog.TouchDate = touchLog.TouchDate;
            existingTouchLog.AmountOfTime = touchLog.AmountOfTime;

            _unitOfWork.TouchLog.Update(existingTouchLog);

            var result = _unitOfWork.Save();
            return result > 0;
        }

    }
}
