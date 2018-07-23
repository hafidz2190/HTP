using POProject.CommandAdapter;
using System;
using System.Data;

namespace POProject.DataAccess
{
    public class SPTPDData
    {
        public static DataTable RetrieveDataSptpd(string username, int masapajak, int tahun, bool isActive, double pajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select ID_SPTPD, USERNAME, MASAPAJAK, TAHUN, PAJAK, SANKSI, TOTAL, ID_BAYAR, IS_ACTIVE 
                                from sptpd 
                            where username=:usern and masapajak=:masapajak and tahun =:tahun and is_active =:isactive and pajak=:pjk";
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("masapajak", OracleCmdParameterDirection.Input, masapajak);
            cmd.AddParameter("tahun", OracleCmdParameterDirection.Input, tahun);
            cmd.AddParameter("isactive", OracleCmdParameterDirection.Input, isActive);
            cmd.AddParameter("pjk", OracleCmdParameterDirection.Input, pajak);

            return cmd.GetTable();
        }

        public static DataTable RetrieveDataSptpdById(string idSptpd)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select ID_SPTPD, USERNAME, MASAPAJAK, TAHUN, PAJAK, SANKSI, TOTAL, ID_BAYAR, IS_ACTIVE 
                                from sptpd 
                            where id_sptpd=:idsptpd";
            cmd.AddParameter("idsptpd", OracleCmdParameterDirection.Input, idSptpd);
            return cmd.GetTable();
        }

        public static bool InsertSptpd(string idsptpd, string username, int masapajak, int tahun, double pajak, double sanksi, double total, string idbayar)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO SPTPD (ID_SPTPD, USERNAME, MASAPAJAK, TAHUN, PAJAK, SANKSI, TOTAL, ID_BAYAR)
                            VALUES (:idsptpd, :usern, :masapajak, :tahun, :pajak, :sanksi, :total, :idbayar)";
            cmd.AddParameter("idsptpd", OracleCmdParameterDirection.Input, idsptpd);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("masapajak", OracleCmdParameterDirection.Input, masapajak);
            cmd.AddParameter("tahun", OracleCmdParameterDirection.Input, tahun);
            cmd.AddParameter("pajak", OracleCmdParameterDirection.Input, pajak);
            cmd.AddParameter("sanksi", OracleCmdParameterDirection.Input, sanksi);
            cmd.AddParameter("total", OracleCmdParameterDirection.Input, total);
            cmd.AddParameter("idbayar", OracleCmdParameterDirection.Input, idbayar);
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public class SPTPDDetailData
    {
        public static DataTable RetrieveDetailSptpd(string idSptpd, string username)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select ID_SPTPD, NOP, USERNAME, MASAPAJAK, TAHUN, ROUND(NOMINAL,0) NOMINAL from sptpd_detail
                                where id_sptpd=:idsptpd and username=:usern";
            cmd.AddParameter("idsptpd", OracleCmdParameterDirection.Input, idSptpd);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            return cmd.GetTable();

        }

        public static DataTable RetrieveDetailSptpdByNop(string idSptpd, string nop)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select ID_SPTPD, NOP, USERNAME, MASAPAJAK, TAHUN, ROUND(NOMINAL,0) NOMINAL from sptpd_detail
                                where id_sptpd=:idsptpd and nop=:nop";
            cmd.AddParameter("idsptpd", OracleCmdParameterDirection.Input, idSptpd);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            return cmd.GetTable();

        }

        public static bool InsertDetailSptpd(string idsptpd, string nop, string username, int masapajak, int tahun, double pajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"INSERT INTO SPTPD_DETAIL (ID_SPTPD, NOP, USERNAME, MASAPAJAK, TAHUN, NOMINAL)
                            VALUES (:idsptpd, :nop, :usern, :masapajak, :tahun, :pajak)";
            cmd.AddParameter("idsptpd", OracleCmdParameterDirection.Input, idsptpd);
            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("usern", OracleCmdParameterDirection.Input, username);
            cmd.AddParameter("masapajak", OracleCmdParameterDirection.Input, masapajak);
            cmd.AddParameter("tahun", OracleCmdParameterDirection.Input, tahun);
            cmd.AddParameter("pajak", OracleCmdParameterDirection.Input, pajak);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateIsGenerate(string nop, DateTime tanggal)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"UPDATE USER_TRANSACTION SET IS_GENERATE=1
                            WHERE NOP=:nop AND trunc(tanggal) = :tgl";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tanggal.Date);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool isSptpdDetailByNop(string nop, int masapajak, int tahun)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT count(*) FROM SPTPD_DETAIL WHERE NOP=:nop AND MASAPAJAK=:mp AND TAHUN=:thn";

            cmd.AddParameter("nop", OracleCmdParameterDirection.Input, nop);
            cmd.AddParameter("mp", OracleCmdParameterDirection.Input, masapajak);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahun);

            int jml = 0;

            try
            {
                jml = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

            }

            return jml > 0;
        }
    }
}