using EMQV.Models;
using EMQV.Models.Helper;
using EMQV.Models.Master;
using EMQV.Models.Purchase;
using EMQV.Models.Startup;
using KumonRPages.Models;
using KumonRPages.ModernModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMQV.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        //Startup
        public DbSet<GroupReport> GroupReport { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<Migration> Migration { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<ReportDocument> ReportDocument { get; set; }
        public DbSet<ReportDocumentDetail> ReportDocumentDetail { get; set; }
        public DbSet<Server> Server { get; set; }
        public DbSet<UpdateFile> UpdateFile { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        //Master
        public DbSet<BusinessPartner> BusinessPartner { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccount { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Salesman> Salesman { get; set; }
        public DbSet<ItemAverage> ItemAverage { get; set; }
        //public DbSet<SpecialTag> SpecialTags { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<TermOfPayment> TermOfPayment { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<SystemConfig> SystemConfig { get; set; }
        public DbSet<ViewAverageDetail> ViewAverageDetail { get; set; }
        //Purchase
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}