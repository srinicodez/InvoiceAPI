using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace InvoiceAPI.Models
{
    public partial class TblInvoiceDatum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeqId { get; set; }
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
