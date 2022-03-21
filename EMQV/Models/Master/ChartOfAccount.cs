using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class ChartOfAccount
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ChartOfAccountID { get; set; }//1
        [Column(TypeName = "varchar(16)")]
        public string? GroupAccountID { get; set; }//2
        [Column(TypeName = "varchar(128)")]
        public string? AccountNo { get; set; }//3
        [Column(TypeName = "varchar(128)")]
        public string? Description { get; set; }//4
        [Column(TypeName = "varchar(16)")]
        public string? ParentID { get; set; }//5
        public bool? IsChildest { get; set; }//6
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "varchar(16)")]
        public string? Type2 { get; set; }//8
        public string? Type { get; set; }//9
        public bool? IsBank { get; set; }//10
        public bool? IsCard { get; set; }//11
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
        [Timestamp]
        public byte[] Timestamp { get; set; }//15
    }
}
