using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.BusinessLogic.Entity
{
    public class SPTPD
    {
        public string ID_SPTPD { get; set; }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Sanksi { get; set; }
        public double Total { get; set; }
        public string Id_Bayar { get; set; }
        public bool Is_Active { get; set; }
    }

    public class SPTPDDetail
    {
        public string ID_SPTPD { get; set; }
        public string Nop { get; set; }
        public NopBaru ObyekPajak
        {
            get
            {
                return NopBaruBusiness.RetrieveNopBaru(Nop);
            }
        }
        public string Username { get; set; }
        public int MasaPajak { get; set; }
        public int Tahun { get; set; }
        public double Nominal { get; set; }
        public string StrNominal { get { return this.Nominal.AsCurrencyNonRp(); } }
    }
}
