using EMQV.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;

namespace EMQV.Repository.Category
{
    public interface ICategoryRepository
    {
        EMQV.Models.Master.Category Find(string id);
        List<EMQV.Models.Master.Category> GetAll();
        EMQV.Models.Master.Category Add(EMQV.Models.Master.Category category);
        EMQV.Models.Master.Category Update(EMQV.Models.Master.Category category);

        EMQV.Models.Master.Category FindMaxID(string id);
        bool HaveData();

        void Remove(int Id);


    }
}
