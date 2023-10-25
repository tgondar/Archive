using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    internal class CourtDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<CourtEntity> GetAutocomplete(string term)
        {
            return from c in db.tb_Court
                   where c.Name.ToUpper().Contains(term)
                   orderby c.Name
                   select new CourtEntity()
                   {
                       Active = (c.Active == 1),
                       Address = c.Address,
                       AlterDate = c.AlterDate,
                       CourtId = c.CourtId,
                       CreateDate = c.CreateDate,
                       Email = c.Email,
                       Fax = c.Fax,
                       JudicialDistrict = c.JudicialDistrict,
                       Name = c.Name,
                       Phone = c.Phone
                   };
        }
    }
}
