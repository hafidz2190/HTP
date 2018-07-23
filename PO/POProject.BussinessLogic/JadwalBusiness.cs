using POProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.BusinessLogic
{
   public class JadwalBusiness
    {

        public static bool InsertJadwal(DateTime tanggal, string obyekpajak, string alamat, string vendor, string jam, string kegiatan, DateTime modidate, string status, string petugas)
        {
            return JadwalData.InsertJadwal("1", tanggal, obyekpajak, alamat, vendor, jam, kegiatan, modidate, status, petugas);
        }

        public static bool UpdateJadwal(string idop, DateTime tanggal, string obyekpajak, string alamat, string vendor, string jam, string kegiatan, DateTime modidate, string status, string petugas)
        {
            return JadwalData.UpdateJadwal(idop, tanggal, obyekpajak, alamat, vendor, jam, kegiatan, modidate, status, petugas);
        }

        public static bool DeleteJadwal(string id)
        {
            return JadwalData.DeleteJadwal(id);
        }

        public static DataTable GetJadwal()
        {
            return JadwalData.GetJadwal();
        }

        public static DataTable GetJadwal1()
        {
            return JadwalData.GetJadwal1();
        }

        public static DataTable GetJadwal2()
        {
            return JadwalData.GetJadwal2();
        }

        public static DataTable GetJadwal3()
        {
            return JadwalData.GetJadwal3();
        }

        public static DataTable GetJadwal4()
        {
            return JadwalData.GetJadwal4();
        }
       
        } 
    
}
