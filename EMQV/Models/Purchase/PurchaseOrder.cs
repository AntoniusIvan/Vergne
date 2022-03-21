using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Purchase
{
    public class PurchaseOrder
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string PurchaseOrderID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? VoucherNo { get; set; }//2
        [Column(TypeName = "varchar(16)")]
        public string? BranchID { get; set; }//3
        [Column(TypeName = "varchar(16)")]
        public string? DepartmentID { get; set; }//4
        [Column(TypeName = "datetime")]
        public DateTime? TransDate { get; set; }//5
        [Column(TypeName = "varchar(256)")]
        public string? ReferenceNo { get; set; }//6
        [Column(TypeName = "varchar(16)")]
        public string? BusinessPartnerID { get; set; }//7
        public bool? IsDeleted { get; set; }//8
        [Column(TypeName = "varchar(16)")]
        public string? TermOfPaymentID { get; set; }//9
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }//10
        [Column(TypeName = "varchar(512)")]
        public string? Notes { get; set; }//11
        public bool? IsClosed { get; set; }//12
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Amount { get; set; }//13
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Disc { get; set; }//14
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? DiscValue { get; set; }//15
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? DiscRp { get; set; }//16
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Tax { get; set; }//17
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? TaxValue { get; set; }//18
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Netto { get; set; }//19
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? Rate { get; set; }//20



        //[Column(TypeName = "decimal(24, 10) ")]
        //public decimal? ServiceTax { get; set; }//21
        //[Column(TypeName = "decimal(28, 10)")]
        //public decimal? ServiceTaxValue { get; set; }//22
        //[Column(TypeName = "decimal(18, 10)")]
        //public decimal? DiscRpBefore { get; set; }//23
        //[Column(TypeName = "datetime")]
        //public DateTime? ModifiedDate { get; set; }//24
        //public int? StatusForm { get; set; }//25
        //[Column(TypeName = "varchar(16)")]
        //public string CurrencyID { get; set; }//26
        //[Column(TypeName = "decimal](23, 4)")]
        //public decimal? Paid { get; set; }//27
        //[Column(TypeName = "datetime")]
        //public DateTime? PaidDate { get; set; }//28
        //public bool? IsInvoiced { get; set; }//29
        //[Column(TypeName = "varchar(528)")]
        //public string AddressInvoice { get; set; }//30
        //[Timestamp]
        //public byte[] Timestamp { get; set; }//31
        //[Column(TypeName = "varchar(1024)")]
        //public string NotesDelivery { get; set; }//32
        //[Column(TypeName = "varchar(16)")]
        //public string AddressDeliveryID { get; set; }//33
        //[Column(TypeName = "varchar(528)")]
        //public string AddressDelivery { get; set; }//34
        //[Column(TypeName = "varchar(50)")]
        //public string ProjectID { get; set; }//35
        //[Column(TypeName = "varchar(16) ")]
        //public string BillOfQuantityID { get; set; }//36
        //[Column(TypeName = "varchar(16)")]
        //public string PurchaseRequestID { get; set; }//37
        //[Column(TypeName = "varchar(16)")]
        //public string SalesmanID { get; set; }//38
        //[Column(TypeName = "varchar(16)")]
        //public string QuotationID { get; set; }//39
        //public bool? IsDirectPurchaseInvoice { get; set; }//40
        //[Column(TypeName = "decimal(23, 10)")]
        //public decimal? Value { get; set; }//41

        //private DateTime _createdDate;
        //public DateTime? CreatedDate
        //{
        //    get
        //    {
        //        if (QuestionID != 0)
        //        {
        //            return _createdDate;
        //        }
        //        else
        //        {
        //            return DateTime.Now;
        //        }

        //    }
        //    set { _createdDate = value; }
        //}

        //BATAS TEST

        //public string isSuspended { get; set; }
        //public string Author { get; set; }
        //public string ISBN { get; set; }
        //public string name { get; set; }
        //
        //public string unit2 { get; set; }
        //public string unit3 { get; set; }
        //public string brandID { get; set; }
        //public string COGSID { get; set; }
        //public string GRIRID { get; set; }
        //public string purchase { get; set; }
        //public string sales { get; set; }
        //public string itemDelivered { get; set; }
        //public string itemReceived { get; set; }
        //public decimal buyPrice1 { get; set; }
        //public decimal buyPrice2 { get; set; }
        //public decimal buyPrice3 { get; set; }
        //public decimal qty { get; set; }
        //public decimal ratio2 { get; set; }
        //public decimal ratio3 { get; set; }
        //public decimal unitPrice2 { get; set; }
        //public decimal unitPrice3 { get; set; }
        //public decimal unitPrice4 { get; set; }
        //public decimal unitPrice5 { get; set; }
        //public decimal unitPrice6 { get; set; }
        //public decimal unitPrice7 { get; set; }
        //public string custom1 { get; set; }
        //public string custom3 { get; set; }
        //public decimal minQty { get; set; }
        //public bool? Concerned { get; set; }

    }
}
