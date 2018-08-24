using System;

namespace POProject.Model
{
    public class UpdateVersion : BaseEntity
    {
        public string version { get; set; }
        public string path_directory { get; set; }
        public int is_important { get; set; }
        public DateTime create_date { get; set; }
        public int islatestversion { get; set; }
    }
}
