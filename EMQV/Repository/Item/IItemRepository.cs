using EMQV.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;

namespace EMQV.Repository.Item
{
    public interface IItemRepository
    {
        EMQV.Models.Master.Item Find(string id);
        List<EMQV.Models.Master.Item> GetRepAll();
        EMQV.Models.Master.Item GetSelectedFor(EMQV.Models.Master.Item item);
        EMQV.Models.Master.Item Add(EMQV.Models.Master.Item item);
        EMQV.Models.Master.Item Update(EMQV.Models.Master.Item item);

        EMQV.Models.Master.Item FindMaxID(string id);
        bool HaveData();

        void Remove(string Id);

        List<EMQV.Models.Master.Item> SelectAllApi();
        List<EMQV.Models.Master.Item> SelectTry2();


    }
}
