using EMQV.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;

namespace EMQV.Repository.SubCategory
{
    public interface ISubCategoryRepository
    {
        EMQV.Models.Master.SubCategory Find(int id);
        List<EMQV.Models.Master.SubCategory> GetAll();
        EMQV.Models.Master.SubCategory Add(EMQV.Models.Master.SubCategory subCategory);
        EMQV.Models.Master.SubCategory Update(EMQV.Models.Master.SubCategory subCategory);

        EMQV.Models.Master.SubCategory FindMaxID(string id);
        bool HaveData();

        void Remove(string Id);


    }
}
