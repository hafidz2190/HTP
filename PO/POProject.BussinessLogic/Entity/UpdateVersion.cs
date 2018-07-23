using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POProject.BusinessLogic.Entity
{
    public class UpdateVersion
    {
        public string version { get; set; }
        public string path_directory { get; set; }
        public int is_important { get; set; }
        public DateTime create_date { get; set; }
        public int islatestversion { get; set; }
    }
}
