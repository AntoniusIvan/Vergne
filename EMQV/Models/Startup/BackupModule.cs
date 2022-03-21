using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class BackupModule
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string BackupModuleID { get; set; }//1
		[Column(TypeName = "varchar(128)")]
		public string? Code { get; set; }//2
		[Column(TypeName = "varchar(128)")]
		public string? Display { get; set; }//3
		[Column(TypeName = "varchar(128)")]
		public string? Type { get; set; }//4
		[Column(TypeName = "varchar(1024)")]
		public string? GroupName { get; set; }//5
		public bool? IsDeleted { get; set; }//6
		[Column(TypeName = "datetime")]
		public DateTime? ModifiedDate { get; set; }//7
		[Timestamp]
		public byte[] Timestamp { get; set; }//8

	}
}
