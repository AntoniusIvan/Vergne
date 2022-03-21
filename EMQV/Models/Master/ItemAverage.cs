using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class ItemAverage
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ItemAverageID { get; set; }//1
		public int? Year { get; set; }//2
		public int? Month { get; set; }//3
		[Column(TypeName = "varchar(16)")]
		public string? ItemId { get; set; }//4
		[Column(TypeName = "decimal(23, 10)")]
		public decimal? Average { get; set; }//5
		public bool? IsDeleted { get; set; }//6
		[Column(TypeName = "decimal(23, 10)")]
		public decimal? AverageDiff { get; set; }//7
		public DateTime? ModifiedDate { get; set; }//14
		[Timestamp]
		public byte[] Timestamp { get; set; }//15
	}
}
