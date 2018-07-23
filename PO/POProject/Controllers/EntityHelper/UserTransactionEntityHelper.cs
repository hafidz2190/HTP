using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POWebClient.Controllers.EntityHelper
{
    public class UserTransactionEntityHelper
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Tanggal { get; set; }
        public double Pajak_Terutang { get; set; }
        public string Keterangan { get; set; }
        public bool Is_Adjusment { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip_Sender { get; set; }
    }
}