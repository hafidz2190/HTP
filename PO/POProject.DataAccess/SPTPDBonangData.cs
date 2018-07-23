using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class SPTPDBonangData
    {
        public static DataTable RetrieveSptpdPayment(string kdValidasi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandBonang();
            cmd.Query = @"SELECT * FROM sptpd_payment WHERE ref_bill=:ids";

            cmd.AddParameter("ids", OracleCmdParameterDirection.Input, kdValidasi);

            return cmd.GetTable();
        }

        public static DataTable RetrieveVirtualAccount(string idSptpd)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandBonang();
            cmd.Query = @"SELECT * FROM virtualaccount_bank WHERE trx_id=:idSpt";
            cmd.AddParameter("idSpt", OracleCmdParameterDirection.Input, idSptpd);

            return cmd.GetTable();
        }

        public static string GetNamaOPSptpd(string kdValidasi)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandBonang();
            cmd.Query = @"SELECT namaop FROM sptpd_baru WHERE id_sptpd=:ids";

            cmd.AddParameter("ids", OracleCmdParameterDirection.Input, kdValidasi);

            return cmd.ExecuteScalar().ToString();
        }
    }
}
