using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class MyTableData
    {
        public static DataTable Retrieve()
        {
            MsAccessCmdBuilder cmd = DataBaseHelper.CreateMsAccessCommand();
            cmd.Query = "SELECT * FROM MYTABLE";
            return cmd.GetTable();
        }
    }
}
