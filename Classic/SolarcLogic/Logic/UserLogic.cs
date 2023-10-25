using SolarcLogic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Logic
{
    public class UserLogic
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<string> GetUsers()
        {
            return (from u in db.aspnet_Users
                    join uir in db.aspnet_UsersInRoles on u.UserId equals uir.UserId
                    join r in db.aspnet_Roles on uir.RoleId equals r.RoleId
                    where r.RoleName != "Representative"
                    orderby u.UserName
                    select u.UserName.ToLower()).ToList();
        }
    }
}
