using POProject.Model;

namespace POProject.BusinessLogic.BusinessDataModel
{
    public class SerialNoteBusinessDataModel : SerialNote
    {
        public string Dec_Kode
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(Kode, BusinessHelpers.Surabaya);
            }
        }

        public string Dec_Taken_Username
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(Taken_Username, BusinessHelpers.Surabaya);
            }
        }

        public string Dec_Taken_HW_ID
        {
            get
            {
                return POAdministrationTools.StringCipher.Decrypt(Taken_HW_ID, BusinessHelpers.Surabaya);
            }
        }
    }
}
