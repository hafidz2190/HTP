using POProject.BusinessLogic.BusinessDataModel;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public interface ISerialNoteBusiness
    {
        List<SerialNoteBusinessDataModel> RetrieveAvailableSerialNote();
        List<SerialNoteBusinessDataModel> RetrieveTakenSerialNote();
        bool UpdateData(string enckode, string username, string hwID);
    }
}