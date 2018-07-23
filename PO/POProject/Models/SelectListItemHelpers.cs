using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace POWebClient.Models
{
    public class SelectListItemHelpers
    {
        internal static List<SelectListItem> GetDataBank(string selectedValue)
        {
            List<Bank> list = BankBusiness.RetrieveDataBank(string.Empty);

            Dictionary<string, string> jenisInput = new Dictionary<string, string>();
            jenisInput.Add("", "- SELECT BANK -");
            foreach (Bank item in list)
            {
                jenisInput.Add(item.Kode_Bank, item.Nama_Bank);
            }

            selectedValue = string.IsNullOrEmpty(selectedValue) ? "" : selectedValue;

            var listInput = from l in jenisInput
                            select new SelectListItem
                            {
                                Selected = string.Compare(l.Key, selectedValue) == 0,
                                Text = l.Value,
                                Value = l.Key
                            };

            return listInput.ToList();
        }
    }
}