using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class ReportDocumentDetail
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string ReportDocumentDetailID { get; set; }//1
        [Column(TypeName = "varchar(16)")]
        public string ReportDocumentID { get; set; }//2
        [Column(TypeName = "varchar(128)")]
        public string Caption { get; set; }//3
        [Column(TypeName = "varchar(128)")]
        public string FilterType { get; set; }//4
        [Column(TypeName = "varchar(128)")]
        public string ParameterName { get; set; }//5
        [Column(TypeName = "varchar(128)")]
        public string DefaultValue { get; set; }//6
        [Column(TypeName = "varchar(128)")]
        public string FieldDescription { get; set; }//7
        [Column(TypeName = "varchar(128)")]
        public string FieldID { get; set; }//8
        [Column(TypeName = "varchar(128)")]
        public string TableName { get; set; }//9
        public int Seq { get; set; }//10
        [Column(TypeName = "varchar(128)")]
        public string Cond { get; set; }//11

	}
}
