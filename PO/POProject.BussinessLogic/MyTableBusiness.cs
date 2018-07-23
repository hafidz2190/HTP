using POProject.BusinessLogic.Entity;
using POProject.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class MyTableBusiness
    {
        public static List<MyTable> Retrieve()
        {
            return MyTableData.Retrieve().AsEnumerable<MyTable>().ToList();

        }
    }
}
