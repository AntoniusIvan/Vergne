using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class Department
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string DepartmentID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? Name { get; set; }//2
        [Column(TypeName = "varchar(128)")]
        public string? Code { get; set; }//3
        public byte[] DepartmentLogo { get; set; }//4
        public bool? IsMembership { get; set; }//5
        public bool? IsPackage { get; set; }//6
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
		[Timestamp]
		public byte[] Timestamp { get; set; }//15
	}
}
