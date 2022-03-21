using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class SalesOrderDetail
    {
        public string SalesOrderDetailID { get; set; }
        [Display(Name = "Order")]
        public int OrderId { get; set; }
        [Display(Name = "Item")]
        public string? ItemID { get; set; }

        [ForeignKey("OrderId")]
        public SalesOrder Order { get; set; }
        [ForeignKey("ItemID")]
        public Item Item { get; set; }

    }
}
