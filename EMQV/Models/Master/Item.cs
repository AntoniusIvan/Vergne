using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Master
{
    public partial class Item
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ItemID { get; set; }//1
        [Required]
        public string? Code { get; set; }//2
        [Column(TypeName = "varchar(768)")] 
        public string? Barcode { get; set; }//3
        public string? Name { get; set; }//4
        [Column(TypeName = "varchar(8)")]
        public string? Unit1 { get; set; }//5
        [Column(TypeName = "varchar(16)")]
        public string? GRIR { get; set; }//6
        public bool? IsActive { get; set; }//6
        public bool? IsDeleted { get; set; }//7
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? UnitPrice1 { get; set; }//11
        public string? GroupItem { get; set; }//8
        //[Column(TypeName = "varchar(16)")]
        //public string? CategoryID { get; set; }//9
        //Ivan 2021-11-21
        [Display(Name = "Category")]
        //[Required]
        public string? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }//9
        [Column(TypeName = "varchar(16)")]
        //public string? BrandID { get; set; }//10
        //Ivan 2021-11-21
        [Display(Name = "Brand")]
        //[Required]
        public string? BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        [Column(TypeName = "varchar(512)")]
        public string? Notes { get; set; }//12
        public bool? IsBuyable { get; set; }//13
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//14
        [Timestamp]
        public byte[] Timestamp { get; set; }//15
        public bool? IsSellable { get; set; }//16
        [Column(TypeName = "datetime")]
        public DateTime? LicenseStart { get; set; }//17
        [Column(TypeName = "datetime")]
        public DateTime? LicenseEnd { get; set; }//18
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Decmdf1 { get; set; }//18
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Decmdf2 { get; set; }//19
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Decmdf3 { get; set; }//20
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Decmdf4 { get; set; }//21
        [Column(TypeName = "decimal(23, 4)")]
        public decimal? Decmdf5 { get; set; }//22
        public string? TemporaryCustom { get; set; }//23
        public int? Seq { get; set; }//24
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? Seq2 { get; set; }//25
        [Column(TypeName = "varchar(511)")]
        public string? Custom1 { get; set; }//26
        [Column(TypeName = "varchar(511)")]
        public string? Custom2 { get; set; }//27
        [Column(TypeName = "varchar(511)")]
        public string? Custom3 { get; set; }//28
        [Column(TypeName = "varchar(511)")]
        public string? Custom4 { get; set; }//29
        [Column(TypeName = "varchar(511)")]
        public string? Custom5 { get; set; }//30
        [Column(TypeName = "varchar(511)")]
        public string? Custom6 { get; set; }//30
        [Column(TypeName = "varchar(511)")]
        public string? Custom7 { get; set; }//30
        [Column(TypeName = "varchar(511)")]
        public string? Custom8 { get; set; }//30
        [Column(TypeName = "varchar(511)")]
        public string? Custom9 { get; set; }//30
        public string? CustomCode { get; set; }//31
        public string? SubCategoryID { get; set; }//32
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? Length { get; set; }//33
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? Width { get; set; }//34
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? Height { get; set; }//35
        public int? Intmdf1 { get; set; }//36
        [Column(TypeName = "varchar(16)")]
        public string? DepartmentID { get; set; }//37
        [Column(TypeName = "varchar(16)")]
        public string? Purchase { get; set; }//38
        [Column(TypeName = "varchar(16)")]
        public string? Sales { get; set; }//39
        [Column(TypeName = "varchar(16)")]
        public string? COGSID { get; set; }//40
        public string? Image { get; set; }//41
        [Display(Name = "Available")]
        public bool? IsAvailable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomDate1 { get; set; }//14
        [Column(TypeName = "datetime")]
        public DateTime? CustomDate2 { get; set; }//14
        

    }
}
