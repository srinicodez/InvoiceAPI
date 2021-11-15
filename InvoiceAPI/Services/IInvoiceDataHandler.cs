using InvoiceAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceAPI.Services
{
    public interface IInvoiceDataHandler
    {
        Task<List<InvoiceModel>> GetAllInvoicessAsync();
        Task<InvoiceModel> GetInvoiceByNumber(string invoiceNum);

        Task<string> AddInvoiceSync(InvoiceModel invoiceModel);
        Task<InvoiceModel> GetIdByInvoice(string invoiceNum);

        Task UpdateInvoiceAsync(string InvNum, InvoiceModel invoicemodel);

        Task DeletenvoiceAsync(string InvNum);

        Task UpdateInvoicePatchAsync(string InvNum, JsonPatchDocument invoicemodel);


    }
}
