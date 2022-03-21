using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class SystemConfig
    {
        [Key]
        [Column(TypeName = "varchar(128)")]
        public string Code { get; set; }//1
        [Column(TypeName = "varchar(2048)")]
        public string? Value { get; set; }//2
        [Column(TypeName = "varchar(1024)")]
        public string? GroupName { get; set; }//3
        [Column(TypeName = "varchar(1050)")]
        public string? Comment { get; set; }//4
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
		[Timestamp]
		public byte[] Timestamp { get; set; }//15
	}
}
