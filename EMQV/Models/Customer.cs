using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KumonRPages.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
        [Timestamp]
        public byte[] Timestamp { get; set; }//15
    }
}