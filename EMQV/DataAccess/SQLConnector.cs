using EMQV.Interface;
using EMQV.Models.Master;
using EMQV.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMQV.DataAccess
{
    public class SQLConnector : iDataConnection
    {
        public void CreateBusinessPartner(BusinessPartner model)
        {
            throw new NotImplementedException();
        }

        public void CreateCategory(Category model)
        {
            throw new NotImplementedException();
        }

        public void CreateDepartment(Department model)
        {
            throw new NotImplementedException();
        }

        public void CreateItem(Item model)
        {
            throw new NotImplementedException();
        }

        public void CreatePurchaseOrder(PurchaseOrder model)
        {
            throw new NotImplementedException();
        }

        public Department FindDepartmentByID(string departmentID, Department model)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseOrderDetail> FindDetailsById(string purchaseOrderID)
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder FindHeaderById(string purchaseOrderID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategory_All()
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartment_All()
        {
            throw new NotImplementedException();
        }

        public void UpdateBusinessPartner(BusinessPartner model)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department model)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item model)
        {
            throw new NotImplementedException();
        }
    }
}
