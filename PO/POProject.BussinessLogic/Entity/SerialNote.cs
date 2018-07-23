using System;

namespace POProject.BusinessLogic.Entity
{
    public class SerialNote
    {
        public string Kode { get; set; }

        public string Dec_Kode
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(this.Kode, BusinessHelpers.Surabaya);
            }
        }
        public string Taken_Username { get; set; }
        public string Dec_Taken_Username
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(this.Taken_Username, BusinessHelpers.Surabaya);
            }
        }

        public string Taken_HW_ID { get; set; }
        public string Dec_Taken_HW_ID
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(this.Taken_HW_ID, BusinessHelpers.Surabaya);
            }
        }

        public DateTime Create_Date { get; set; }
        public string Status { get; set; }
        public string Dec_Status
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(this.Status, BusinessHelpers.Surabaya);
            }
        }
        public DateTime ModiDate { get; set; }
    }
}
