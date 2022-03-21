using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Purchase
{
    public class PurchaseOrderDetail
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string PurchaseOrderDetailID { get; set; }//1
        [Column(TypeName = "varchar(128)")]
        public string? PurchaseOrderID { get; set; }//2
        [Column(TypeName = "varchar(16)")]
        public string? ItemID { get; set; }//3
        [Column(TypeName = "varchar(1080)")]
        public string? Name { get; set; }//4
        public float? Qty { get; set; }//5
        public float? Price { get; set; }//6
        [Column(TypeName = "varchar(16)")]
        public string? Unit { get; set; }//7
        public float? Disc { get; set; }//8
        public float? DiscRp { get; set; }//9
        public float? Amount { get; set; }//10
        public float? Ratio { get; set; }//11
        public float? UnitRatio { get; set; }//12
        public float? DiscValue { get; set; }//8
        public float? Netto { get; set; }//8
        [Column(TypeName = "decimal(24,10)")]
        public decimal? Cashback { get; set; }//8





        //[] [decimal](18, 10) NULL,
        //[BillOfQuantityID] [varchar] (16) NULL,
        //[JobID] [varchar] (16) NULL,
        //[WorkID] [varchar] (16) NULL,

    }
}
