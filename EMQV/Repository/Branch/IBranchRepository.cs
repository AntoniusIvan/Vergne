using EMQV.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;

namespace EMQV.Repository.Branch
{
    public interface IBranchRepository
    {
        EMQV.Models.Master.Branch Find(string id);
        IEnumerable<EMQV.Models.Master.Branch> GetAll();
        EMQV.Models.Master.Branch Add(EMQV.Models.Master.Branch branch);
        EMQV.Models.Master.Branch Update(EMQV.Models.Master.Branch branch);

        EMQV.Models.Master.Branch FindMaxID(string id);
        bool HaveData();

        void Remove(int Id);


    }
}
