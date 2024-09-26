using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class QryBlankSalePrintGreenSheetMainService : IQryBlankSalePrintGreenSheetMainService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public QryBlankSalePrintGreenSheetMainService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateSalePrintGreenSheet(QryBlankSalePrintGreenSheetMain sheet)
        {
            if (sheet != null)
            {
               
                await _unitOfWork.QryBlankSalePrintGreenSheetMain.Insert(sheet);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSalePrintGreenSheet(int id)
        {
            if (id > 0)
            {
                var sheet = await _unitOfWork.QryBlankSalePrintGreenSheetMain.GetById(id);
                if (sheet != null)
                {
                    _unitOfWork.QryBlankSalePrintGreenSheetMain.Delete(sheet);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<QryBlankSalePrintGreenSheetMain>> GetAllSalePrintGreenSheet()
        {
            var sheets = await _unitOfWork.QryBlankSalePrintGreenSheetMain.GetAll();
            return sheets; ;
        }

        public async Task<QryBlankSalePrintGreenSheetMain> GetSalePrintGreenSheetById(int id)
        {
            if (id > 0)
            {
                var sheet = await _unitOfWork.QryBlankSalePrintGreenSheetMain.GetById(id);
                if (sheet != null)
                {
                    return sheet;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSalePrintGreenSheet(QryBlankSalePrintGreenSheetMain sheet)
        {
            if (sheet == null)
            {
                return false;
            }

            var existingBlankSale = await _unitOfWork.QryBlankSalePrintGreenSheetMain.GetById(sheet.Invoice_ID); // Assuming Invoice_ID is the ID
            if (existingBlankSale == null)
            {
                return false;
            }

            // Update the properties of the existing sheet
            existingBlankSale.ID = sheet.ID;
            existingBlankSale.Invoice_ID = sheet.Invoice_ID;
            existingBlankSale.Customer_ID = sheet.Customer_ID;
            existingBlankSale.Sale_Date = sheet.Sale_Date;
            existingBlankSale.Print_Location = sheet.Print_Location;
            existingBlankSale.First_Name = sheet.First_Name;
            existingBlankSale.Trouble = sheet.Trouble;
            existingBlankSale.Cancel = sheet.Cancel;
            existingBlankSale.Total = sheet.Total;
            existingBlankSale.VerifiedAmount = sheet.VerifiedAmount;
            existingBlankSale.CardNumber = sheet.CardNumber;
            existingBlankSale.Rush = sheet.Rush;
            existingBlankSale.Payment_Method = sheet.Payment_Method;
            existingBlankSale.RushBlue = sheet.RushBlue;
            existingBlankSale.ImprintInstructions = sheet.ImprintInstructions;
            existingBlankSale.Verified_Date = sheet.Verified_Date;
            existingBlankSale.VerifierNotes = sheet.VerifierNotes;
            existingBlankSale.ComputerProof = sheet.ComputerProof;
            existingBlankSale.TypeProof = sheet.TypeProof;
            existingBlankSale.Typeset = sheet.Typeset;
            existingBlankSale.PressProof = sheet.PressProof;
            existingBlankSale.Printed = sheet.Printed;
            existingBlankSale.Zip = sheet.Zip;
            existingBlankSale.OrderNotes = sheet.OrderNotes;
            existingBlankSale.Last_Name = sheet.Last_Name;
            existingBlankSale.ShipToName = sheet.ShipToName;
            existingBlankSale.ShipToAddressLine1 = sheet.ShipToAddressLine1;
            existingBlankSale.ShipToAddressLine2 = sheet.ShipToAddressLine2;
            existingBlankSale.ShipToCity = sheet.ShipToCity;
            existingBlankSale.ShipToState = sheet.ShipToState;
            existingBlankSale.ShipToZip = sheet.ShipToZip;
            existingBlankSale.ShipToPhone1 = sheet.ShipToPhone1;
            existingBlankSale.ShipToPhone2 = sheet.ShipToPhone2;
            existingBlankSale.Product = sheet.Product;
            existingBlankSale.Color1 = sheet.Color1;
            existingBlankSale.Color2 = sheet.Color2;
            existingBlankSale.Quantity = sheet.Quantity;
            existingBlankSale.AdCopy = sheet.AdCopy;
            existingBlankSale.AdditionalNotes = sheet.AdditionalNotes;
            existingBlankSale.GreenSheetTotal = sheet.GreenSheetTotal;

            // Perform the update in the database
            _unitOfWork.QryBlankSalePrintGreenSheetMain.Update(existingBlankSale);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }
    }
}
