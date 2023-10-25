using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Dal
{
    internal class CreditorDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<string> GetCreditor(string term)
        {
            term = term.ToUpper();

            var q = from c in db.tb_Creditor
                    where c.Name.ToUpper().Contains(term)
                    orderby c.Name
                    select c.Name;

            return q;
        }
    }
}
