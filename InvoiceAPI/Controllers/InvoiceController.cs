using InvoiceAPI.Models;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceDataHandler _invoiceDataHandler;



        public InvoiceController(IInvoiceDataHandler invoiceDataHandler)
        {
            _invoiceDataHandler = invoiceDataHandler;

        }




        [HttpGet("GetAllInvoices")]                                                        // returns all invoice records based on invoice number

        public async Task<IActionResult> GetAllInvoice()
        {
            var books = await _invoiceDataHandler.GetAllInvoicessAsync();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }


        [HttpGet("{InvoiceNumber}")]                                                        // returns invoice record based on invoice number

        public async Task<IActionResult> GetInvoiceByNumber(string InvoiceNumber)
        {
            var books = await _invoiceDataHandler.GetInvoiceByNumber(InvoiceNumber);
            return Ok(books);
        }


        [HttpPost("")]

        public async Task<IActionResult> AddNewInvoice([FromBody] InvoiceModel invoiceModel)    // Adds a new invoice record based on invoice number
        {
            string ID = await _invoiceDataHandler.AddInvoiceSync(invoiceModel);


            return CreatedAtAction(nameof(GetInvoiceByNumber), new { ID = ID, Controller = "Invoice" }, ID);
        }

       


        [HttpPut("{InvoiceNumber}")]                                                              // modifies-updates invoice record based on invoice number

        public async Task<IActionResult> UpdateBook([FromBody] InvoiceModel invoiceModel, [FromRoute] string InvoiceNumber)
        {
            await _invoiceDataHandler.UpdateInvoiceAsync(InvoiceNumber, invoiceModel);

            return Ok();
        }


        [HttpPatch("{InvoiceNumber}")]                                                             // Updates invoice record  based on invoice number

        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument invoiceModel, [FromRoute] string InvoiceNumber)
        {
            await _invoiceDataHandler.UpdateInvoicePatchAsync(InvoiceNumber, invoiceModel);

            return Ok();
        }


        [HttpDelete("{InvoiceNumber}")]                                                             // Deletes invoice record based on invoice number

        public async Task<IActionResult> DeleteInvoice([FromRoute] string InvoiceNumber)
        {
            await _invoiceDataHandler.DeletenvoiceAsync(InvoiceNumber);

            return Ok();
        }

    }
}
