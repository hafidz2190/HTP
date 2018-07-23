using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POWebClient.Models
{
    public class UserTransactionViewModels
    {
        public List<UserTransaction> UserTransactionList { get; set; }
        public string Username { get; set; }
        //username, 
        public DateTime Tanggal { get; set; }
        public double PajakTerutang { get; set; }
        public string Keterangan { get; set; }
        public bool IsAdjusment { get; set; }
        public DateTime CreateDate { get; set; }
        public string IpSender { get; set; }
    }
}