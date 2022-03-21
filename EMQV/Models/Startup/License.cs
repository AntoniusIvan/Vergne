using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class License
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string LicenseID { get; set; }//1
		[Column(TypeName = "varchar(128)")]
		public string? CMNMCrypo { get; set; }//2
		[Column(TypeName = "varchar(128)")]
		public string? SRLNCrypo { get; set; }//3
		[Column(TypeName = "varchar(128)")]
		public string? PRGTCrypo { get; set; }//4
		[Column(TypeName = "varchar(128)")]
		public string? MCUCrypo { get; set; }//5
		[Column(TypeName = "varchar(128)")]
		public string? EPRDCrypo { get; set; }//6
		[Column(TypeName = "varchar(128)")]
		public bool? IsDeleted { get; set; }//7
		[Column(TypeName = "varchar(128)")]
		public string? CDTCrypo { get; set; }//8
		public string? MDLCrypo { get; set; }//9
		[Column(TypeName = "datetime")]
		public DateTime? ModifiedDate { get; set; }//10
		[Column(TypeName = "varchar(128)")]
		public string? CompanyName { get; set; }//11
		[Timestamp]
		public byte[] Timestamp { get; set; }

	}
}
