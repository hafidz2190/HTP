using POProject.BusinessLogic.BusinessData;
using POProject.BusinessLogic.BusinessDataModel;
using POProject.BusinessLogic.Helper;
using POProject.Model;
using System.Collections.Generic;

namespace POProject.BusinessLogic
{
    public class SerialNoteBusiness : ISerialNoteBusiness
    {
        private readonly ISerialNoteBusinessData _serialNoteBusinessData;

        public SerialNoteBusiness(ISerialNoteBusinessData serialNoteBusinessData)
        {
            _serialNoteBusinessData = serialNoteBusinessData;
        }

        public List<SerialNoteBusinessDataModel> RetrieveAvailableSerialNote()
        {
            return ModelToBusinessModelMapper.Convert<SerialNote, SerialNoteBusinessDataModel>(_serialNoteBusinessData.RetrieveAvailableSerialNote());
        }

        public List<SerialNoteBusinessDataModel> RetrieveTakenSerialNote()
        {
            return ModelToBusinessModelMapper.Convert<SerialNote, SerialNoteBusinessDataModel>(_serialNoteBusinessData.RetrieveTakenSerialNote());
        }

        public bool UpdateData(string enckode, string username, string hwID)
        {
            return _serialNoteBusinessData.UpdateData(enckode, username, hwID);
        }
    }
}
