using POProject.CommandAdapter;
using System;
using System.Data;

namespace POProject.DataAccess
{
    public class JadwalData
    {
        public static DataTable GetJadwal()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"SELECT tanggal, obyek_pajak, alamat, nama_vendor, jam, kegiatan, status, petugas from JADWAL_ONLINE
                          where status1 not in '0'";
                        
            return cmd.GetTable();
        }

        public static DataTable GetJadwal1()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"SELECT tanggal, obyek_pajak, alamat, nama_vendor, jam, kegiatan, status, petugas from JADWAL_ONLINE
                          where status in 'BELUM ADA FEEDBACK' and status1 not in '0'";

            return cmd.GetTable();
        }

        public static DataTable GetJadwal2()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"SELECT tanggal, obyek_pajak, alamat, nama_vendor, jam, kegiatan, status, petugas from JADWAL_ONLINE
                          where status in 'SUDAH TERPASANG' and status1 not in '0'";

            return cmd.GetTable();
        }

        public static DataTable GetJadwal3()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"SELECT tanggal, obyek_pajak, alamat, nama_vendor, jam, kegiatan, status, petugas from JADWAL_ONLINE
                          where status in 'AKAN SEGERA DIPASANG' and status1 not in '0'";

            return cmd.GetTable();
        }

        public static DataTable GetJadwal4()
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"SELECT tanggal, obyek_pajak, alamat, nama_vendor, jam, kegiatan, status, petugas from JADWAL_ONLINE
                          where status in 'MENUNGGU KOORDINASI LEBIH LANJUT' and status1 not in '0'";

            return cmd.GetTable();
        }

        public static bool InsertJadwal(string idop, DateTime tanggal, string obyekpajak, string alamat, string vendor, string jam, string kegiatan,DateTime modidate, string status, string petugas)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"INSERT INTO JADWAL_ONLINE (IDOP, TANGGAL, OBYEK_PAJAK, ALAMAT, NAMA_VENDOR, JAM, KEGIATAN, MODIDATE, STATUS, PETUGAS)
                           VALUES (:id, :tgl, :op, :almt, :ven, :jm, :keg, :moddate, :stat, :ptg)";

            //cmd.AddParameter("id", OracleCmdParameterDirection.Input, idop);
            cmd.AddParameter("id", OracleCmdParameterDirection.Input, Guid.NewGuid().ToString());
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tanggal);
            cmd.AddParameter("op", OracleCmdParameterDirection.Input, obyekpajak);
            cmd.AddParameter("almt", OracleCmdParameterDirection.Input, alamat);
            cmd.AddParameter("ven", OracleCmdParameterDirection.Input, vendor);
            cmd.AddParameter("jm", OracleCmdParameterDirection.Input, jam);
            cmd.AddParameter("keg", OracleCmdParameterDirection.Input, kegiatan);
            cmd.AddParameter("moddate", OracleCmdParameterDirection.Input, modidate);           
            cmd.AddParameter("stat", OracleCmdParameterDirection.Input, status);
            cmd.AddParameter("ptg", OracleCmdParameterDirection.Input, petugas);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateJadwal(string idop, DateTime tanggal, string obyekpajak, string alamat, string vendor, string jam, string kegiatan, DateTime modidate, string status, string petugas)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"UPDATE JADWAL_ONLINE SET IDOP=:id, tanggal=:tgl, obyek_pajak=:op, alamat=:almt, nama_vendor=:ven, jam=:jm, kegiatan=:keg,
                          modidate=:moddate, status=:stat, petugas=:ptg";

            cmd.AddParameter("id", OracleCmdParameterDirection.Input, Guid.NewGuid().ToString());
            cmd.AddParameter("tgl", OracleCmdParameterDirection.Input, tanggal);
            cmd.AddParameter("op", OracleCmdParameterDirection.Input, obyekpajak);
            cmd.AddParameter("almt", OracleCmdParameterDirection.Input, alamat);
            cmd.AddParameter("ven", OracleCmdParameterDirection.Input, vendor);
            cmd.AddParameter("jm", OracleCmdParameterDirection.Input, jam);
            cmd.AddParameter("keg", OracleCmdParameterDirection.Input, kegiatan);
            cmd.AddParameter("moddate", OracleCmdParameterDirection.Input, modidate);
            cmd.AddParameter("stat", OracleCmdParameterDirection.Input, status);
            cmd.AddParameter("ptg", OracleCmdParameterDirection.Input, petugas);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool DeleteJadwal (string id)
        {
            OracleCmdBuilder cmd = DataBaseHelper.CreateOracleCommandElang();
            cmd.Query = @"DELETE FROM JADWAL_ONLINE WHERE IDOP=@id";
            cmd.AddParameter("id", OracleCmdParameterDirection.Input, id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
