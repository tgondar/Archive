using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Dal
{
    internal class RepresentativeDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<string> GetRepresentative(string term)
        {
            term = term.ToUpper();

            var q = db.tb_Representative.Where(p => p.Name.ToUpper().Contains(term)).OrderBy(p => p.Name).Select(p => p.Name);

            return q;
        }
    }
}
