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
    public class BlankSalesService : IBlankSalesService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public BlankSalesService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateBlankSale(BlankSale blankSale)
        {
            if (blankSale != null)
            {
               
                await _unitOfWork.BlankSales.Insert(blankSale);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteBlankSale(int id)
        {
            if (id > 0)
            {
                var blankSale = await _unitOfWork.BlankSales.GetById(id);
                if (blankSale != null)
                {
                    _unitOfWork.BlankSales.Delete(blankSale);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<BlankSale>> GetAllBlankSales()
        {
            var blankSales = await _unitOfWork.BlankSales.GetAll();
            return blankSales;
        }

        public async Task<BlankSale> GetBlankSaleById(int id)
        {
            if (id > 0)
            {
                var blankSale = await _unitOfWork.BlankSales.GetById(id);
                if (blankSale != null)
                {
                    return blankSale;
                }
            }
            return null;
        }

        public async Task<bool> UpdateBlankSale(BlankSale blankSale)
        {
            if (blankSale == null)
            {
                return false;
            }

            var existingBlankSale = await _unitOfWork.BlankSales.GetById(blankSale.ID);
            if (existingBlankSale == null)
            {
                return false;
            }

            // Update the properties of the existing blankSale
            existingBlankSale.Invoice_ID = blankSale.Invoice_ID;
            existingBlankSale.Customer_ID = blankSale.Customer_ID;
            existingBlankSale.Sale_Date = blankSale.Sale_Date;
            existingBlankSale.Sale_Type = blankSale.Sale_Type;
            existingBlankSale.Payment_Method = blankSale.Payment_Method;
            existingBlankSale.Check_Date = blankSale.Check_Date;
            existingBlankSale.Check_Amount = blankSale.Check_Amount;
            existingBlankSale.Card_Number = blankSale.Card_Number;
            existingBlankSale.CreditCardLastFourDigits = blankSale.CreditCardLastFourDigits;
            existingBlankSale.Fronter = blankSale.Fronter;
            existingBlankSale.Closer = blankSale.Closer;
            existingBlankSale.Verifier = blankSale.Verifier;
            existingBlankSale.Verified_Date = blankSale.Verified_Date;
            existingBlankSale.SGI_Rec_Date = blankSale.SGI_Rec_Date;
            existingBlankSale.SGI_Type_Date = blankSale.SGI_Type_Date;
            existingBlankSale.Ship_Date = blankSale.Ship_Date;
            existingBlankSale.Return_Date = blankSale.Return_Date;
            existingBlankSale.Return_Type = blankSale.Return_Type;
            existingBlankSale.Return_Amount = blankSale.Return_Amount;
            existingBlankSale.Print_Location = blankSale.Print_Location;
            existingBlankSale.Total = blankSale.Total;
            existingBlankSale.Input_Date = blankSale.Input_Date;
            existingBlankSale.Rush = blankSale.Rush;
            existingBlankSale.Shipping = blankSale.Shipping;
            existingBlankSale.SubTotal = blankSale.SubTotal;
            existingBlankSale.Front_Comm = blankSale.Front_Comm;
            existingBlankSale.Closer_Comm = blankSale.Closer_Comm;
            existingBlankSale.Total_Comm = blankSale.Total_Comm;
            existingBlankSale.Trouble = blankSale.Trouble;
            existingBlankSale.Cancel = blankSale.Cancel;
            existingBlankSale.OrderNotes = blankSale.OrderNotes;
            existingBlankSale.VerifiedAmount = blankSale.VerifiedAmount;
            existingBlankSale.ImprintInstructions = blankSale.ImprintInstructions;
            existingBlankSale.VerifierNotes = blankSale.VerifierNotes;
            existingBlankSale.ComputerProof = blankSale.ComputerProof;
            existingBlankSale.TypeProof = blankSale.TypeProof;
            existingBlankSale.Typeset = blankSale.Typeset;
            existingBlankSale.PressProof = blankSale.PressProof;
            existingBlankSale.Printed = blankSale.Printed;
            existingBlankSale.RushBlue = blankSale.RushBlue;
            existingBlankSale.ShipToName = blankSale.ShipToName;
            existingBlankSale.ShipToAddressLine1 = blankSale.ShipToAddressLine1;
            existingBlankSale.ShipToAddressLine2 = blankSale.ShipToAddressLine2;
            existingBlankSale.ShipToCity = blankSale.ShipToCity;
            existingBlankSale.ShipToState = blankSale.ShipToState;
            existingBlankSale.ShipToZip = blankSale.ShipToZip;
            existingBlankSale.ShipToPhone1 = blankSale.ShipToPhone1;
            existingBlankSale.ShipToPhone2 = blankSale.ShipToPhone2;
            existingBlankSale.AdditionalNotes = blankSale.AdditionalNotes;
            existingBlankSale.GreenSheetTotal = blankSale.GreenSheetTotal;
            existingBlankSale.Owner = blankSale.Owner;
            existingBlankSale.CCNumber = blankSale.CCNumber;
            existingBlankSale.CCName = blankSale.CCName;
            existingBlankSale.CCExpire = blankSale.CCExpire;
            existingBlankSale.Product = blankSale.Product;
            existingBlankSale.Quantity = blankSale.Quantity;
            existingBlankSale.ItemColor = blankSale.ItemColor;
            existingBlankSale.ImprintColor = blankSale.ImprintColor;
            existingBlankSale.AdCopy = blankSale.AdCopy;
            existingBlankSale.SLSNumber = blankSale.SLSNumber;
            existingBlankSale.SalesPerson = blankSale.SalesPerson;
            existingBlankSale.CCCode = blankSale.CCCode;
            existingBlankSale.Company_Name = blankSale.Company_Name;
            existingBlankSale.First_Name = blankSale.First_Name;
            existingBlankSale.Last_Name = blankSale.Last_Name;
            existingBlankSale.Address = blankSale.Address;
            existingBlankSale.Address2 = blankSale.Address2;
            existingBlankSale.City = blankSale.City;
            existingBlankSale.State = blankSale.State;
            existingBlankSale.Zip = blankSale.Zip;
            existingBlankSale.Phone1 = blankSale.Phone1;
            existingBlankSale.Phone1_Ext = blankSale.Phone1_Ext;
            existingBlankSale.Phone2 = blankSale.Phone2;
            existingBlankSale.Phone2_Ext = blankSale.Phone2_Ext;
            existingBlankSale.LastSaveDateTime = blankSale.LastSaveDateTime;
            existingBlankSale.upsize_ts = blankSale.upsize_ts;

            // Perform the update in the database
            _unitOfWork.BlankSales.Update(existingBlankSale);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }

        public async Task<IEnumerable<BlankSale>> GetSalesCount(SalesFilter filter)
        {
            // Parse the startDate and endDate strings to DateTime
            if (!DateTime.TryParse(filter.StartDate, out var parsedStartDate) ||
                !DateTime.TryParse(filter.EndDate, out var parsedEndDate))
            {
                throw new ArgumentException("Invalid date format for startDate or endDate.");
            }

            // Fetch all BlankSales
            var blankSales = await _unitOfWork.BlankSales.GetAll();

            // Filter the sales
            var filteredSales = blankSales.Where(s => s.SalesPerson == filter.UserID &&
                                                      s.Sale_Date > parsedStartDate &&
                                                      s.Sale_Date < parsedEndDate);

            return filteredSales;
        }




    }
}
