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
    public class InvoicesService : IInvoicesService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public InvoicesService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateInvoice(Invoice invoice)
        {
            if (invoice != null)
            {
               
                await _unitOfWork.Invoices.Insert(invoice);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            if (id > 0)
            {
                var invoice = await _unitOfWork.Invoices.GetById(id);
                if (invoice != null)
                {
                    _unitOfWork.Invoices.Delete(invoice);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var invoices = await _unitOfWork.Invoices.GetAll();
            return invoices; ;
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            if (id > 0)
            {
                var invoice = await _unitOfWork.Invoices.GetById(id);
                if (invoice != null)
                {
                    return invoice;
                }
            }
            return null;
        }

        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                return false;
            }

            var existingInvoice = await _unitOfWork.Invoices.GetById(invoice.ID);
            if (existingInvoice == null)
            {
                return false;
            }

            // Update the properties of the existing invoice
            existingInvoice.Invoice_ID = invoice.Invoice_ID;
            existingInvoice.Customer_ID = invoice.Customer_ID;
            existingInvoice.Sale_Date = invoice.Sale_Date;
            existingInvoice.Sale_Type = invoice.Sale_Type;
            existingInvoice.Payment_Method = invoice.Payment_Method;
            existingInvoice.Check_Date = invoice.Check_Date;
            existingInvoice.Check_Amount = invoice.Check_Amount;
            existingInvoice.Card_Number = invoice.Card_Number;
            existingInvoice.CreditCardLastFourDigits = invoice.CreditCardLastFourDigits;
            existingInvoice.Fronter = invoice.Fronter;
            existingInvoice.Closer = invoice.Closer;
            existingInvoice.Verifier = invoice.Verifier;
            existingInvoice.Verified_Date = invoice.Verified_Date;
            existingInvoice.SGI_Rec_Date = invoice.SGI_Rec_Date;
            existingInvoice.SGI_Type_Date = invoice.SGI_Type_Date;
            existingInvoice.Ship_Date = invoice.Ship_Date;
            existingInvoice.Return_Date = invoice.Return_Date;
            existingInvoice.Return_Amount = invoice.Return_Amount; // Corrected property name
            existingInvoice.Print_Location = invoice.Print_Location;
            existingInvoice.Total = invoice.Total;
            existingInvoice.Input_Date = invoice.Input_Date;
            existingInvoice.Rush = invoice.Rush;
            existingInvoice.Shipping = invoice.Shipping;
            existingInvoice.SubTotal = invoice.SubTotal;
            existingInvoice.Front_Comm = invoice.Front_Comm;
            existingInvoice.Closer_Comm = invoice.Closer_Comm;
            existingInvoice.Total_Comm = invoice.Total_Comm;
            existingInvoice.Trouble = invoice.Trouble;
            existingInvoice.Cancel = invoice.Cancel;
            existingInvoice.OrderNotes = invoice.OrderNotes;
            existingInvoice.VerifiedAmount = invoice.VerifiedAmount;
            existingInvoice.ImprintInstructions = invoice.ImprintInstructions;
            existingInvoice.VerifierNotes = invoice.VerifierNotes;
            existingInvoice.ComputerProof = invoice.ComputerProof;
            existingInvoice.TypeProof = invoice.TypeProof;
            existingInvoice.Typeset = invoice.Typeset;
            existingInvoice.PressProof = invoice.PressProof;
            existingInvoice.Printed = invoice.Printed;
            existingInvoice.RushBlue = invoice.RushBlue;
            existingInvoice.ShipToName = invoice.ShipToName;
            existingInvoice.ShipToAddressLine1 = invoice.ShipToAddressLine1;
            existingInvoice.ShipToAddressLine2 = invoice.ShipToAddressLine2;
            existingInvoice.ShipToCity = invoice.ShipToCity;
            existingInvoice.ShipToState = invoice.ShipToState;
            existingInvoice.ShipToZip = invoice.ShipToZip;
            existingInvoice.ShipToPhone1 = invoice.ShipToPhone1;
            existingInvoice.ShipToPhone2 = invoice.ShipToPhone2;
            existingInvoice.ShipToFirstName = invoice.ShipToFirstName;
            existingInvoice.ShipToLastName = invoice.ShipToLastName;
            existingInvoice.AdditionalNotes = invoice.AdditionalNotes;
            existingInvoice.GreenSheetTotal = invoice.GreenSheetTotal;
            existingInvoice.LastSaveDateTime = invoice.LastSaveDateTime;
            existingInvoice.Upsize_ts = invoice.Upsize_ts;
            existingInvoice.SalesOrOffice = invoice.SalesOrOffice;

            // Perform the update in the database
            _unitOfWork.Invoices.Update(existingInvoice);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }
    }
}
