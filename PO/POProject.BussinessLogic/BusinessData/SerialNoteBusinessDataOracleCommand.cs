using POProject.DataAccess;
using POProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic.BusinessData
{
    public class SerialNoteBusinessDataOracleCommand : ISerialNoteBusinessData
    {
        public List<SerialNote> RetrieveAvailableSerialNote()
        {
            return SerialNoteData.RetrieveAvailableSerialNote().AsEnumerable<SerialNote>().ToList();
        }

        public List<SerialNote> RetrieveTakenSerialNote()
        {
            return SerialNoteData.RetrieveAllTakenSerialNote().AsEnumerable<SerialNote>().ToList();
        }

        public bool UpdateData(string enckode, string username, string hwID)
        {
            return SerialNoteData.UpdateData(enckode, username, hwID);
        }
    }
}