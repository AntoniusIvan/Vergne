using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class Category
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string CategoryID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? Name { get; set; }//2
        [Column(TypeName = "varchar(128)")]
        public string? Code { get; set; }//2

        public bool? IsFood { get; set; }//3
        public bool? IsBeverage { get; set; }//4
        public bool? IsOther { get; set; }//5
        [Required]
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
		[Timestamp]
		public byte[] Timestamp { get; set; }//15
	}
}
