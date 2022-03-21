using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class ViewAverageDetail
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string VADID { get; set; }//1
        [Column(TypeName = "varchar(1024)")]
        public string? VoucherNo { get; set; }//2
		[Column(TypeName = "datetime")]
		public DateTime? TransDate { get; set; }//3
		[Column(TypeName = "varchar(16)")]
		public string? ItemId { get; set; }//4
		[Column(TypeName = "decimal(23, 10)")]
		public decimal? Qty { get; set; }//5
		[Column(TypeName = "decimal(23, 10)")]
		public decimal? Amount { get; set; }//6
		[Column(TypeName = "varchar(256)")]
		public string? Type { get; set; }//7
		public int? TransType { get; set; }//8
		[Column(TypeName = "varchar(16)")]
		public string? BranchID { get; set; }//9
		[Column(TypeName = "varchar(16)")]
		public string? DepartmentID { get; set; }//10
		[Column(TypeName = "varchar(50)")]
		public string? ID { get; set; }//11

		[Timestamp]
		public byte[] Timestamp { get; set; }//15
	}
}
