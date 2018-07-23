using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POWebClient.Models
{
    public class DetailSptpdViewModels
    {
        public List<SPTPDDetail> ListDetail { get; set; }
        public string IdSptpd { get; set; }
        public string encIdSptpd
        {
            get
            {
                return Pemkot.Encryption.Crypto.ActionEncrypt(IdSptpd);
            }
        }
        public string TotalPembayaran { get; set; }
    }
}