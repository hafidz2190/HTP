using System;

namespace POProject.Model
{
    public class SerialNote : BaseEntity
    {
        public string Kode { get; set; }
        public string Taken_Username { get; set; }
        public string Taken_HW_ID { get; set; }
        public DateTime Create_Date { get; set; }
        public string Status { get; set; }
        public string Dec_Status { get; set; }
        public DateTime ModiDate { get; set; }
    }
}