using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMQV.Interface
{
    public interface IPrintManager
    {
        void Print(string printCode, string printCodeSufix, string oid, string printName = "", string addCondition = "", bool isPrintID = false);
    }
}
