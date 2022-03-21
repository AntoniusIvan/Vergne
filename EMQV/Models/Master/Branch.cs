using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class Branch
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string BranchID { get; set; }//1s
        [Column(TypeName = "varchar(128)")]
        public string? Name { get; set; }//2
        [Column(TypeName = "varchar(16)")]
        public string? Code { get; set; }//3
		[Column(TypeName = "varchar(128)")]
		public string? Address1 { get; set; }//4
		[Column(TypeName = "varchar(128)")]
		public string? Address2 { get; set; }//5
		[Column(TypeName = "varchar(128)")]
		public string? Address3 { get; set; }//6
		public bool? IsDeleted { get; set; }//7
		[Column(TypeName = "datetime")]
		public DateTime? ModifiedDate { get; set; }//14
		//[Timestamp]
		//public byte[] Timestamp { get; set; }//15
		[Column(TypeName = "varchar(128)")]
		public string? Phone { get; set; }//16
		[Column(TypeName = "varchar(128)")]
		public string? Email { get; set; }//17
		[Column(TypeName = "varchar(16)")]
		public string? CityID { get; set; }//18
		[Column(TypeName = "varchar(128)")]
		public string? Position { get; set; }//19
		[Column(TypeName = "varchar(128)")]
		public string? PIC { get; set; }//20
		[Column(TypeName = "varchar(20)")]
		public string? TaxNo { get; set; }//21
	}
}
