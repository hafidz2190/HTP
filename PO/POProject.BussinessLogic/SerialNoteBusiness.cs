using POProject.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class SerialNoteBusiness
    {
        public static List<Entity.SerialNote> RetrieveAvailableSerialNote()
        {
            return SerialNoteData.RetrieveAvailableSerialNote().AsEnumerable<Entity.SerialNote>().ToList();
        }

        public static List<Entity.SerialNote> RetrieveTakenSerialNote()
        {
            return SerialNoteData.RetrieveAllTakenSerialNote().AsEnumerable<Entity.SerialNote>().ToList();
        }

        public static bool UpdateData(string enckode, string username, string hwID)
        {
            return SerialNoteData.UpdateData(enckode, username, hwID);
        }
    }
}
