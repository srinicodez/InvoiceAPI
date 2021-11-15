
using InvoiceAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceAPI.Services
{
    public class InvoiceDataHandler : IInvoiceDataHandler
    {


        private readonly Invoice_DataContext _context;



        public InvoiceDataHandler(Invoice_DataContext Context)
        {
            _context = Context;

        }




        public async Task<List<InvoiceModel>> GetAllInvoicessAsync()
        {



            var records = await _context.TblInvoiceData.Select(x => new InvoiceModel()
            {
                Id = x.Id,
                DueDate = x.DueDate,
                InvoiceNo = x.InvoiceNo,
                InvoiceDate = x.InvoiceDate,
                CompanyName = x.CompanyName,
                TotalDue = x.TotalDue,
                CompanyEmail = x.CompanyEmail,
                Ponumber = x.Ponumber,
                CompanyAddress = x.CompanyAddress,
                CompanyPhoneNo = x.CompanyPhoneNo,
                SubTotal = x.SubTotal,
                SalesTax = x.SalesTax,
                BillToAddress = x.BillToAddress,
                AudEquivalent = x.AudEquivalent

            }).ToListAsync();

            return records;


        }




        public async Task<InvoiceModel> GetInvoiceByNumber(string invoiceNum)
        {

            var records = await _context.TblInvoiceData.Where(x => x.InvoiceNo == invoiceNum).Select(x => new InvoiceModel()
            {
                Id = x.Id,
                DueDate = x.DueDate,
                InvoiceNo = x.InvoiceNo,
                InvoiceDate = x.InvoiceDate,
                CompanyName = x.CompanyName,
                TotalDue = x.TotalDue,
                CompanyEmail = x.CompanyEmail,
                Ponumber = x.Ponumber,
                CompanyAddress = x.CompanyAddress,
                CompanyPhoneNo = x.CompanyPhoneNo,
                SubTotal = x.SubTotal,
                SalesTax = x.SalesTax,
                BillToAddress = x.BillToAddress,
                AudEquivalent = x.AudEquivalent


            }).FirstOrDefaultAsync();


            return records;


        }

        public async Task<InvoiceModel> GetIdByInvoice(string id)
        {

            var invID = await _context.TblInvoiceData.Where(x => x.Id == id).Select(x => new InvoiceModel()
            {
                Id = x.Id,



            }).FirstOrDefaultAsync();


            return invID;


        }



        public async Task<string> AddInvoiceSync(InvoiceModel invoiceModel)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            var invoice = new TblInvoiceDatum()
            {
                Id = invoiceModel.Id,

                DueDate = invoiceModel.DueDate,
                InvoiceNo = invoiceModel.InvoiceNo,
                InvoiceDate = invoiceModel.InvoiceDate,
                CompanyName = invoiceModel.CompanyName,
                TotalDue = invoiceModel.TotalDue,
                CompanyEmail = invoiceModel.CompanyEmail,
                Ponumber = invoiceModel.Ponumber,
                CompanyAddress = invoiceModel.CompanyAddress,
                CompanyPhoneNo = invoiceModel.CompanyPhoneNo,
                SubTotal = invoiceModel.SubTotal,
                SalesTax = invoiceModel.SalesTax,
                BillToAddress = invoiceModel.BillToAddress,
                AudEquivalent = invoiceModel.AudEquivalent
            };

            _context.TblInvoiceData.Add(invoice);

            await _context.SaveChangesAsync();


            return invoice.Id;
        }

        public async Task UpdateInvoiceAsync(string InvNum, InvoiceModel invoiceModel)
        {
            try
            {
                var invoice = new TblInvoiceDatum()
                {
                    Id = invoiceModel.Id,

                    DueDate = invoiceModel.DueDate,
                    InvoiceNo = invoiceModel.InvoiceNo,
                    InvoiceDate = invoiceModel.InvoiceDate,
                    CompanyName = invoiceModel.CompanyName,
                    TotalDue = invoiceModel.TotalDue,
                    CompanyEmail = invoiceModel.CompanyEmail,
                    Ponumber = invoiceModel.Ponumber,
                    CompanyAddress = invoiceModel.CompanyAddress,
                    CompanyPhoneNo = invoiceModel.CompanyPhoneNo,
                    SubTotal = invoiceModel.SubTotal,
                    SalesTax = invoiceModel.SalesTax,
                    BillToAddress = invoiceModel.BillToAddress,
                    AudEquivalent = invoiceModel.AudEquivalent
                };

                _context.TblInvoiceData.Update(invoice);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                e.ToString();
            }
            

        }


        public async Task UpdateInvoicePatchAsync(string InvNum, JsonPatchDocument invoicemodel)
        {
            try
            {
                var invoice = await _context.TblInvoiceData.FindAsync(InvNum);

                if (invoice != null)
                {
                    invoicemodel.ApplyTo(invoice);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }


        }



        public async Task DeletenvoiceAsync(string InvNum)
        {
            try
            {
                var invoice = new TblInvoiceDatum()                 
                { 
                    InvoiceNo = InvNum 
                
                };

                _context.Remove(invoice);

                await _context.SaveChangesAsync();


                
            }
            catch (Exception e)
            {

                e.ToString();
            }
           

        }
      
    }
}
