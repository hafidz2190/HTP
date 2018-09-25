using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace POProject.BusinessLogic
{
    public static class Mapper
    {
        public static List<SptpdPaymentItem> MapSptpdPayment(DataTable source)
        {
            List<SptpdPaymentItem> result = new List<SptpdPaymentItem>();
            foreach (DataRow row in source.Rows)
            {
                string noBill = BusinessHelpers.GetString(row["REF_BILL"]);
                string splBill = noBill.Substring(0, 4) + " " + noBill.Substring(4, 4) + " " + noBill.Substring(8, 4) + " " + noBill.Substring(12, 4);
                result.Add(new SptpdPaymentItem
                {
                    KdBill = BusinessHelpers.GetString(row["KD_BILL"]),
                    NOP = BusinessHelpers.GetString(row["NOP"]),
                    NamaOP = BusinessHelpers.GetString(row["NAMAOP"]),
                    AlamatOP = BusinessHelpers.GetString(row["ALAMATOP"]),
                    Pajak = BusinessHelpers.GetDouble(row["PAJAK"]),
                    Sanksi = BusinessHelpers.GetDouble(row["SANKSI"]),
                    ReffBill = splBill,
                    MasaPajak = BusinessHelpers.GetInteger(row["MASAPAJAK"]),
                    TahunPajak = BusinessHelpers.GetInteger(row["TAHUNPAJAK"]),
                    TglJthTempo = BusinessHelpers.GetDateTime(row["JATUH_TEMPO"]),
                    StatusAktif = BusinessHelpers.GetInteger(row["STATUS_AKTIF"]),
                    StatusBayar = BusinessHelpers.GetInteger(row["STATUS_BAYAR"])
                });
            }
            return result;
        }

        internal static void CreateMap<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public static List<VirtualAccountBankItem> MapVirtualAccountBank(DataTable source)
        {
            List<VirtualAccountBankItem> result = new List<VirtualAccountBankItem>();
            foreach (DataRow row in source.Rows)
            {
                string strCode = BusinessHelpers.GetString(row["VA_CODE"]);
                result.Add(new VirtualAccountBankItem
                {
                    BankName = BusinessHelpers.GetString(row["BANK_NAME"]),
                    VaCode = strCode.Substring(0, 4) + " " + strCode.Substring(4, 4) + " " + strCode.Substring(8, 4) + " " + strCode.Substring(12, 4)
                });
            }

            return result;
        }
    }
}
