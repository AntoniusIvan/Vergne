using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class UserLog
    {
        [Key]
        [Column(TypeName = "varchar(128)")]
        public string UserLogID { get; set; }//1
        [Column(TypeName = "varchar(16)")]
        public string? UserID { get; set; }//2
        [Column(TypeName = "varchar(128)")]
        public string? ModuleCode { get; set; }//3
        [Column(TypeName = "datetime")]
        public DateTime? TransDate { get; set; }//4
        public string? Description { get; set; }//5
        [Column(TypeName = "varchar(16)")]
        public string? ObjectID { get; set; }//6
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
		[Timestamp]
		public byte[] Timestamp { get; set; }//15

	}
}
