using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;
using SolarcEntities;

namespace SolarcLogic.Logic
{
    public class EntityLogic
    {
        EntityDal edal = new EntityDal();

        private IEnumerable<EntityEnt> GetAllEntities()
        {
            return edal.GetEntities();
        }

        public IEnumerable<EntityEnt> GetLastChangedEntities()
        {
            return edal.GetEntities().OrderBy(p => p.AlterDate).Take(30);
        }

        public void DeleteEntity(int entityId)
        {
            db_solarcDevelopEntities1 db=new db_solarcDevelopEntities1();
            var ent = db.tb_Entity.Single(pp => pp.EntityId == entityId);

            db.tb_Entity.Remove(ent);
            db.SaveChanges();
        }

        public IEnumerable<EntityEnt> GetEntities(string value)
        {
            value = value.ToUpper();
            return edal.GetEntities().Where(p => p.Name.ToUpper().Contains(value));
        }

        public EntityEnt GetEntity(string value)
        {
            return edal.GetEntities().Single(p => p.Name == value);
        }
        public EntityEnt GetEntity(int id)
        {
            return edal.GetEntities().Single(p => p.EntityId == id);
        }

        public void SaveEntity(int entityId,string code, string name, string identityCard, string hPhone, string mPhone, string contactName, string fax, string email, string taxNumber, string address, string postalCode, string observation, string userName,bool active)
        {
            EntityEnt ee = new EntityEnt();

            ee.Active = active;
            ee.EntityId = entityId;
            ee.Code = code;
            ee.Name = name;
            ee.IdentityCard = identityCard;
            ee.HPhone = hPhone;
            ee.MPhone = mPhone;
            ee.ContactName = contactName;
            ee.Fax = fax;
            ee.Email = email;
            ee.TaxNumber = taxNumber;
            ee.EAddress = address;
            ee.PostalCode = postalCode;
            ee.Observation = observation;
            ee.AlterUser = userName;
            ee.CreateUser = userName;

            edal.SaveEntity(ee);
        }
    }
}
