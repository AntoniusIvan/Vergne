using EMQV.Models.Master;
using EMQV.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMQV.Interface
{
    public interface iDataConnection
    {
        //Category
        void CreateCategory(Category model);

        List<Category> GetCategory_All();

        //department
        List<Department> GetDepartment_All();
        void CreateDepartment(Department model);
        void UpdateDepartment(Department model);
        Department FindDepartmentByID(string departmentID, Department model);

        //BusinessPartner
        //List<Department> GetDepartment_All();
        void CreateBusinessPartner(BusinessPartner model);
        void UpdateBusinessPartner(BusinessPartner model);
        //Department FindDepartmentByID(string departmentID, Department model);

        //Item
        void CreateItem(Item model);
        void UpdateItem(Item model);
        //PurchaseOrder
        void CreatePurchaseOrder(PurchaseOrder model);
        List<PurchaseOrderDetail> FindDetailsById(string purchaseOrderID);
        PurchaseOrder FindHeaderById(string purchaseOrderID);

    }
}
