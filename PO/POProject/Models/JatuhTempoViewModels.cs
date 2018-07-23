using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POWebClient.Models
{
    public class JatuhTempoViewModels
    {
        public List<JatuhTempo> ListJatuhTempo { get; set; }

        public List<JatuhTempo> ListMonth { get; set; }

        public IEnumerable<Year> ListTahun { get; set; }

        public double Bulan { get; set; }
        public double Tahun { get; set; }
        public DateTime TglJatuhTempo { get; set; }
    }

    //class ListTahun
    //{
    //    public int Tahun { get; set; }
    //    public List<JatuhTempo> ListJatuhTempo { get; set; }
    //}
}