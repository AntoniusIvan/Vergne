using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class ReportDocument
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ReportDocumentID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? Name { get; set; }//2
        [Column(TypeName = "varchar(16)")]
        public string? GroupReportID { get; set; }//3
        public byte[] SQLQuery { get; set; }//4
        public byte[] Layout { get; set; }//5
        public int Seq { get; set; }//6
        public bool? IsBegin { get; set; }//7
        public bool? IsDeleted { get; set; }//8
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//9
		[Timestamp]
		public byte[] Timestamp { get; set; }//10

	}
}
