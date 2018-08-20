using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic.BusinessData
{
    public interface ISerialNoteBusinessData
    {
        List<SerialNote> RetrieveAvailableSerialNote();
        List<SerialNote> RetrieveTakenSerialNote();
        bool UpdateData(string enckode, string username, string hwID);
    }
}