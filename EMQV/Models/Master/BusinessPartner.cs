using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class BusinessPartner
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string BusinessPartnerID { get; set; }//1
		[Column(TypeName = "varchar(128)")]
		public string? Code { get; set; }//2
		[Column(TypeName = "varchar(128)")]
		public string? Name { get; set; }//3
		[Column(TypeName = "varchar(1024)")]
		public string? Address { get; set; }//4
		public bool? IsDeleted { get; set; }//5
		[Column(TypeName = "varchar(128)")]
		public string? ContactPerson { get; set; }//6
		[Column(TypeName = "varchar(128)")]
		public string? Email { get; set; }//7
		[Column(TypeName = "varchar(50)")]
		public string? FaxNo { get; set; }//8
		[Column(TypeName = "varchar(128)")]
		public string? MobileNo { get; set; }//9
		[Column(TypeName = "varchar(128)")]
		public string? NPWP { get; set; }//10
		[Column(TypeName = "varchar(128)")]
		public string? NPWPName { get; set; }//11
		[Column(TypeName = "varchar(128)")]
		public string? PhoneNo { get; set; }//12
		public bool? IsLoan { get; set; }//13
		public bool? IsSuspended { get; set; }//14
		public bool? IsTax { get; set; }//15
		[Column(TypeName = "varchar(1024) ")]
		public string? Notes { get; set; }//16
		[Column(TypeName = "varchar(1024)")]
		public string? NPWPAddress { get; set; }//17
		[Column(TypeName = "datetime")]
		public DateTime? DateOfBirth { get; set; }//18
		[Column(TypeName = "datetime")]
		public DateTime? JoinDate { get; set; }//19
		[Column(TypeName = "varchar(50)")]
		public string? ClusterID { get; set; }//20
		[Column(TypeName = "varchar(128)")]
		public string? GroupBusinessPartner { get; set; }//21
		[Column(TypeName = "int")]
		public int? PriceLevel { get; set; }//22
		[Column(TypeName = "varchar(16)")]
		public string? AccountPayableID { get; set; }//23
		[Column(TypeName = "varchar(16)")]
		public string? AccountReceivableID { get; set; }//24
		[Column(TypeName = "varchar(16)")]
		public string? SalesDiscID { get; set; }//25
		[Column(TypeName = "varchar(16)")]
		public string? PurchaseDiscID { get; set; }//26
		[Column(TypeName = "varchar(16)")]
		public string? ServiceTaxID { get; set; }//27
		[Column(TypeName = "varchar(16)")]
		public string? TaxInID { get; set; }//28
		[Column(TypeName = "varchar(16)")]
		public string? TaxOutID { get; set; }//29
		[Column(TypeName = "varchar(16)")]
		public string? TermOfPaymentID { get; set; }//30
		[Column(TypeName = "decimal(23, 6)")]
		public decimal? Limit { get; set; }//31
		public bool? IsIncludeTax { get; set; }//32
		[Column(TypeName = "varchar(50)")]
		public string? SalesmanID { get; set; }//33
		[Column(TypeName = "varchar(16)")]
		public string? PurchaseDepositID { get; set; }//34
		[Column(TypeName = "varchar(16)")]
		public string? SalesDepositID { get; set; }//35
		[Column(TypeName = "varchar(50)")]
		public string? AccountReceiveableID { get; set; }//36
		[Column(TypeName = "varchar(62)")]
		public string? Prefix { get; set; }//37
		[Column(TypeName = "varchar(50)")]
		public string? WebPage { get; set; }//38
		[Column(TypeName = "varchar(50)")]
		public string? Gender { get; set; }//39
		[Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//40
		[Timestamp]
		public byte[] Timestamp { get; set; }//41

	}
}
