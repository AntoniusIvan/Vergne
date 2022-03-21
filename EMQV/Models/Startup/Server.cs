using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class Server
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ServerID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? Name { get; set; }//2
        public bool? IsDeleted { get; set; }//6
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
        [Timestamp]
		public byte[] Timestamp { get; set; }//15

	}
}
