using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class GroupReport
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string GroupReportID { get; set; }//1
		[Column(TypeName = "varchar(128)")]
		public string? Name { get; set; }//2
		public int Seq { get; set; }//3
		public bool? IsBeginGroup { get; set; }//4]
		public bool? IsDeleted { get; set; }//6
		[Column(TypeName = "datetime")]
		public DateTime? ModifiedDate { get; set; }//5
		[Timestamp]
		public byte[] Timestamp { get; set; }//7

	}
}
