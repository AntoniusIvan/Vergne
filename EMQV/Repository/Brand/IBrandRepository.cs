using EMQV.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;

namespace EMQV.Repository.Brand
{
    public interface IBrandRepository
    {
        EMQV.Models.Master.Brand Find(string id);
        List<EMQV.Models.Master.Brand> GetAll();
        EMQV.Models.Master.Brand Add(EMQV.Models.Master.Brand brand);
        EMQV.Models.Master.Brand Update(EMQV.Models.Master.Brand brand);

        EMQV.Models.Master.Brand FindMaxID(string id);
        bool HaveData();

        void Remove(int Id);


    }
}
