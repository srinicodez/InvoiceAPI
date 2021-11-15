using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceAPI.Models
{
    public class InvoiceModel
    {
        public string Id { get; set; }
        public string DueDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CompanyName { get; set; }
        public string TotalDue { get; set; }
        public string CompanyEmail { get; set; }
        public string Ponumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhoneNo { get; set; }
        public string SubTotal { get; set; }
        public string SalesTax { get; set; }
        public string BillToAddress { get; set; }
        public string AudEquivalent { get; set; }

    }
}
