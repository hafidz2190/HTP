using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POWebClient.Models
{
    public class UserClientViewModels
    {
        public List<UserClient> UserClientList { get; set; }
        public string Username { get; set; }
        public string IdMachine { get; set; }
        public string Password { get; set; }
        public string WebUsername { get; set; }
        public string SerialKey { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string KodeBank { get; set; }

        public List<SelectListItem> GetBank
        {
            get
            {
                return SelectListItemHelpers.GetDataBank(this.KodeBank);
            }
        }
    }
}