using Data.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using Services;

namespace Data.Accounts
{
    public class DataAccountGetList : DataStrategy
    {
        protected override void Process()
        {          
            List<AccountDTO> accounts = new List<AccountDTO>();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                ServiceAccountRepository serviceAccountRepository = new ServiceAccountRepository(context);



                //List<USER> entityUsers = sAE_Entities.USER.OrderBy(x => x.USERNAME).ToList();

                //foreach (USER entityUser in entityUsers)
                //{
                //    users.Add(new User(entityUser.ID, entityUser.USERNAME, entityUser.IS_ENABLED,
                //        new Profile(entityUser.PROFILE_ID, entityUser.PROFILE.DESCRIPTION, entityUser.PROFILE.IS_ENABLED, new Role(entityUser.PROFILE.ROLE_ID)),
                //        entityUser.EMAIL, entityUser.CUSTOMER_ID));
                //}
            }

            SetResult(accounts);
        }
    }
}
