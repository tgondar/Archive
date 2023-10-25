using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;

namespace SolarcLogic.Logic
{
    public class CreditorLogic
    {
        CreditorDal cd = new CreditorDal();

        public IEnumerable<string> GetCreditor(string term)
        {
            return cd.GetCreditor(term);
        }
    }
}
