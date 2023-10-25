using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    internal class EntityDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<EntityEnt> GetEntities()
        {
            return from en in db.tb_Entity
                   select new EntityEnt()
                   {
                       Active = en.Active,
                       AlterDate = en.AlterDate,
                       AlterUser = en.AlterUser,
                       Code = en.Code,
                       ContactName = en.ContactName,
                       CreateDate = en.CreateDate,
                       CreateUser = en.CreateUser,
                       EAddress = en.EAddress,
                       Email = en.Email,
                       EntityId = en.EntityId,
                       Fax = en.Fax,
                       HPhone = en.HPhone,
                       IdentityCard = en.IdentityCard,
                       MPhone = en.MPhone,
                       Name = en.Name,
                       Observation = en.Observation,
                       PostalCode = en.PostalCode,
                       TaxNumber = en.TaxNumber
                   };
        }
        public IEnumerable<EntityEnt> GetEntitiesAutocomplete(string value)
        {
            value = value.ToUpper();

            return from en in db.tb_Entity
                   where en.Name.ToUpper().Contains(value)
                   select new EntityEnt()
                   {
                       Active = en.Active,
                       AlterDate = en.AlterDate,
                       AlterUser = en.AlterUser,
                       Code = en.Code,
                       ContactName = en.ContactName,
                       CreateDate = en.CreateDate,
                       CreateUser = en.CreateUser,
                       EAddress = en.EAddress,
                       Email = en.Email,
                       EntityId = en.EntityId,
                       Fax = en.Fax,
                       HPhone = en.HPhone,
                       IdentityCard = en.IdentityCard,
                       MPhone = en.MPhone,
                       Name = en.Name,
                       Observation = en.Observation,
                       PostalCode = en.PostalCode,
                       TaxNumber = en.TaxNumber
                   };
        }

        public void SaveEntity(EntityEnt ee)
        {
            tb_Entity te = new tb_Entity();
            if (ee.EntityId != 0)
            {
                te = db.tb_Entity.Single(pp => pp.EntityId == ee.EntityId);
                te.Active = ee.Active;
            }
            else
            {
                te.CreateDate = DateTime.Now;
                te.CreateUser = ee.CreateUser;
                te.Active = true;
            }

            te.AlterDate = DateTime.Now;
            te.AlterUser = ee.AlterUser;
            te.Code = ee.Code;
            te.ContactName = ee.ContactName;
            te.EAddress = ee.EAddress;
            te.Email = ee.Email;
            te.Fax = ee.Fax;
            te.HPhone = ee.HPhone;
            te.IdentityCard = ee.IdentityCard;
            te.MPhone = ee.MPhone;
            te.Name = ee.Name;
            te.Observation = ee.Observation;
            te.PostalCode = ee.PostalCode;
            te.TaxNumber = ee.TaxNumber;

            if (ee.EntityId == 0)
                db.tb_Entity.Add(te);

            db.SaveChanges();
        }
    }
}
