using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public class SalesOrder
    {
        //Chapter 50 04:00 - Order Model 2021 - 07 - 22 18:25
        public SalesOrder()
        {
            SalesOrderDetails =new List<SalesOrderDetail>();
        }
        public int Id { get; set; }
        [Display(Name = "Order No")]
        public string? OrderNo { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public string? PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        
        public DateTime? OrderDate { get; set; }

        public virtual List<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
