using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;

namespace SolarcLogic.Logic
{
    public class ExecutedLogic
    {
        ExecutedDal ed = new ExecutedDal();

        public IEnumerable<string> GetExecuted(string term)
        {
            return ed.GetExecuted(term);
        }
    }
}
