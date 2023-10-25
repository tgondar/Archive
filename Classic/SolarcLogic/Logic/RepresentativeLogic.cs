using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;

namespace SolarcLogic.Logic
{
    public class RepresentativeLogic
    {
        RepresentativeDal rd = new RepresentativeDal();

        public IEnumerable<string> GetRepresentative(string term)
        {
            return rd.GetRepresentative(term);
        }
    }
}
