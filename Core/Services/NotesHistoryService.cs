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
    public class NotesHistoryService : INotesHistoryService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public NotesHistoryService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateNotesHistory(NotesHistory noteHistory)
        {
            if (noteHistory != null)
            {
               
                await _unitOfWork.NotesHistory.Insert(noteHistory);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteNotesHistory(int id)
        {
            if (id > 0)
            {
                var noteHistory = await _unitOfWork.NotesHistory.GetById(id);
                if (noteHistory != null)
                {
                    _unitOfWork.NotesHistory.Delete(noteHistory);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<NotesHistory>> GetAllNotesHistory()
        {
            var noteHistorys = await _unitOfWork.NotesHistory.GetAll();
            return noteHistorys;
        }

        public async Task<NotesHistory> GetNotesHistoryById(int id)
        {
            if (id > 0)
            {
                var noteHistory = await _unitOfWork.NotesHistory.GetById(id);
                if (noteHistory != null)
                {
                    return noteHistory;
                }
            }
            return null;
        }

        public async Task<bool> UpdateNotesHistory(NotesHistory noteHistory)
        {
            if (noteHistory == null)
            {
                return false;
            }

            var existingNotesHistory = await _unitOfWork.NotesHistory.GetById(noteHistory.NoteHistoryID);
            if (existingNotesHistory == null)
            {
                return false;
            }

            // Update the properties of the existing NotesHistory
            existingNotesHistory.CustomerID = noteHistory.CustomerID;
            existingNotesHistory.CustomerIDArchive = noteHistory.CustomerIDArchive;
            existingNotesHistory.EmployeeIDName = noteHistory.EmployeeIDName;
            existingNotesHistory.EmployeeID = noteHistory.EmployeeID;
            existingNotesHistory.NoteDateTime = noteHistory.NoteDateTime;
            existingNotesHistory.Notes = noteHistory.Notes;
            existingNotesHistory.CallBackDateTime = noteHistory.CallBackDateTime;
            existingNotesHistory.DispositionID = noteHistory.DispositionID;
            existingNotesHistory.EndTime = noteHistory.EndTime;
            existingNotesHistory.Upsize_Ts = noteHistory.Upsize_Ts;

            // Perform the update in the database
            _unitOfWork.NotesHistory.Update(existingNotesHistory);

            // Save the changes
            var result =  _unitOfWork.Save();
            return result > 0;
        }



    }
}
