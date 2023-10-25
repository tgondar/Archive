using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;
using SolarcEntities;

namespace SolarcLogic.Logic
{
    public class CourtLogic
    {
        CourtDal cd = new CourtDal();

        public IEnumerable<CourtEntity> GetAutocomplete(string term)
        {
            return cd.GetAutocomplete(term);
        }
    }
}
