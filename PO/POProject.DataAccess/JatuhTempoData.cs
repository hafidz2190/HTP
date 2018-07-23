using POProject.CommandAdapter;
using System.Data;

namespace POProject.DataAccess
{
    public class JatuhTempoData
    {
        public static DataTable RetrieveJatuhTempo(int masaPajak, int tahunPajak)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT bulan, tahun,tgl_jatuh_tempo
                          FROM jatuhtempo_pajak 
                          WHERE bulan=:bln AND tahun=:thn";
           
            cmd.AddParameter("bln", OracleCmdParameterDirection.Input, masaPajak);
            cmd.AddParameter("thn", OracleCmdParameterDirection.Input, tahunPajak);

            return cmd.GetTable();
        }

        public static DataTable RetrieveAllJatuhTempo(int tahun)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"SELECT bulan, tahun,tgl_jatuh_tempo
                          FROM jatuhtempo_pajak ";
            if (tahun != 0)
            {
                cmd.Query += @"where tahun =:thn ";
                cmd.AddParameter(":thn", OracleCmdParameterDirection.Input, tahun);
            }

            return cmd.GetTable();
        }

        public static DataTable RetrieveTahunJatuhTempo()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"Select distinct(tahun) from jatuhtempo_pajak 
                            WHERE tahun between to_number(to_char(sysdate,'yyyy')) - 1 AND to_number(to_char(sysdate,'yyyy')) + 1 
                            order by tahun";
            return cmd.GetTable();
        }

        public static DataTable RetrieveAllowMasaPajak()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommand();
            cmd.Query = @"select bulan, tahun,tgl_jatuh_tempo from jatuhtempo_pajak
                            where tgl_jatuh_tempo >= trunc(sysdate)
                            order by bulan,tahun";
            return cmd.GetTable();
        }
    }
}
