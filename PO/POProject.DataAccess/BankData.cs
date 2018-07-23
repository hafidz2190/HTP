using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class BankData
    {
        public static DataTable RetrieveDataBank(string kdBank)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = "SELECT KODE_BANK, NAMA_BANK, USERNAME FROM BANK ";
            if (!string.IsNullOrEmpty(kdBank))
            {
                cmd.Query += " WHERE KODE_BANK =:kdbank";
                cmd.AddParameter("kdbank", OracleCmdParameterDirection.Input, kdBank);
            }
            return cmd.GetTable();
        }

        public static DataTable RetrieveDataPembayaranByKdBankUser(string kdBank)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT a.ID_SPTPD, a.USERNAME, a.MASAPAJAK, a.TAHUN, a.PAJAK, a.SANKSI,a. TOTAL, a.ID_BAYAR,max(c.nop) as nop
                            FROM SPTPD a 
                            inner join sptpd_detail c ON a.id_sptpd = c.id_sptpd
                            INNER JOIN USER_CLIENT b ON A.USERNAME = b.WEB_USERNAME";
            if (!string.IsNullOrEmpty(kdBank))
            {
                cmd.Query += " WHERE b.KODE_BANK = :kdBank";
                cmd.AddParameter("kdBank", OracleCmdParameterDirection.Input, kdBank);
            }
            cmd.Query += " group by a.ID_SPTPD, a.USERNAME, a.MASAPAJAK, a.TAHUN, a.PAJAK, a.SANKSI,a. TOTAL, a.ID_BAYAR";
            return cmd.GetTable();
        }
    }
}
