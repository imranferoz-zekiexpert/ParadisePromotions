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
    public class TimeZonesService : ITimeZonesService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public TimeZonesService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateTimeZones(TimeZones timeZones)
        {
            if (timeZones != null)
            {
               
                await _unitOfWork.TimeZones.Insert(timeZones);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTimeZones(int id)
        {
            if (id > 0)
            {
                var timeZones = await _unitOfWork.TimeZones.GetById(id);
                if (timeZones != null)
                {
                    _unitOfWork.TimeZones.Delete(timeZones);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<TimeZones>> GetAllTimeZones()
        {
            var timeZoness = await _unitOfWork.TimeZones.GetAll();
            return timeZoness; ;
        }

        public async Task<TimeZones> GetTimeZonesById(int id)
        {
            if (id > 0)
            {
                var timeZones = await _unitOfWork.TimeZones.GetById(id);
                if (timeZones != null)
                {
                    return timeZones;
                }
            }
            return null;
        }

        public async Task<bool> UpdateTimeZones(TimeZones timeZone)
        {
            if (timeZone == null)
            {
                return false;
            }

            // Fetch the existing timeZone item by ID
            var existingTimeZone = await _unitOfWork.TimeZones.GetById(timeZone.TimeZoneID);
            if (existingTimeZone == null)
            {
                return false;
            }

            // Update the properties of the existing timeZone with the new values
            existingTimeZone.AreaCode = timeZone.AreaCode;
            existingTimeZone.Prefix = timeZone.Prefix;
            existingTimeZone.State = timeZone.State;
            existingTimeZone.TimeZone = timeZone.TimeZone;
            existingTimeZone.DST = timeZone.DST;
            existingTimeZone.KCOffset = timeZone.KCOffset;
            existingTimeZone.TimeZoneDesc = timeZone.TimeZoneDesc;

            // Perform the update in the database
            _unitOfWork.TimeZones.Update(existingTimeZone);

            // Save the changes
            var result =  _unitOfWork.Save(); // Make sure to await the SaveAsync method
            return result > 0;
        }

    }
}
