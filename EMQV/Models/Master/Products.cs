using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//tutorial 3

namespace EMQV.Models.Master
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(23, 10)")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [Display(Name = "Product Color")]
        public string? ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool? IsAvailable { get; set; }
        
        [Display(Name = "Product Type")]
        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [Display(Name = "Special Tag")]
        [Required]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public virtual SpecialTag SpecialTag { get; set; }
    }
}
