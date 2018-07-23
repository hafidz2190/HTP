using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.BusinessLogic
{
    public class UserNopBusiness
    {
        public static List<UserNOP> RetrieveNOPByUsername(string username)
        {
            return UserNopData.RetrieveNOPByUsername(username).AsEnumerable<UserNOP>().ToList();
        }
    }
}
