using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class NopBaruData
    {
        public static DataTable RetrieveNopBaru(string Nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            //OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandBonang();
            cmd.Query = @"select NOP, NAMAOP, ALAMAT, NPWPD, KODEREKENING, JENISUSAHA
                                from vw_nop_baru
                            where NOP=:nop";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, Nop);

            return cmd.GetTable();
        }
    }
}
