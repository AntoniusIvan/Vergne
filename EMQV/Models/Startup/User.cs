using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMQV.Models.Startup
{
    public class User
    {
        [Key]
        [Column(TypeName = "varchar(16)")]
        public string UserID { get; set; }//1
		[Column(TypeName = "varchar(128)")]
		public string? Username { get; set; }//2
		[Column(TypeName = "varchar(128)")]
		public string? Password { get; set; }//3
		[Column(TypeName = "varchar(128)")]
		public string? Firstname { get; set; }//4
		[Column(TypeName = "varchar(128)")]
		public string? Lastname { get; set; }//5
		[Column(TypeName = "varchar(1024)")]
		public string? PasswordHash { get; set; }//6
		public bool? IsDeleted { get; set; }//7
		[Column(TypeName = "varchar(128)")]
		public string? MacAddress { get; set; }//8
		public bool? IsAdministrator { get; set; }//9
		public bool? IsLock { get; set; }//10
		public DateTime? LastLogin { get; set; }//11
		[Column(TypeName = "varchar(64)")]
		public string? LastIP { get; set; }//12
		[Column(TypeName = "varchar(256)")]
		public string? LastMachineName { get; set; }//13
		[Column(TypeName = "varchar(16)")]
		public string? RoleID { get; set; }//14
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }//15
		[Timestamp]
		public byte[] Timestamp { get; set; }//16

	}
}
