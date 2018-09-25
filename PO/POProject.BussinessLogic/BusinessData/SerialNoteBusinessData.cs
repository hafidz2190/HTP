using System;
using System.Collections.Generic;
using System.Linq;
using POAdministrationTools;
using POProject.DataAccess;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class SerialNoteBusinessData : ISerialNoteBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public SerialNoteBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public List<SerialNote> RetrieveAvailableSerialNote()
        {
            return _dataManager.Get<SerialNote>((e => e.Status == DataBaseHelper.GetAvailableCommandNote())).ToList();
        }

        public List<SerialNote> RetrieveTakenSerialNote()
        {
            return _dataManager.Get<SerialNote>((e => e.Status != DataBaseHelper.GetAvailableCommandNote())).ToList();
        }

        public bool UpdateData(string enckode, string username, string hwID)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    SerialNote serialNote = _dataManager.GetOne<SerialNote>((e => e.Kode == enckode));

                    if (serialNote == null)
                        return false;
                    else
                    {
                        serialNote.Taken_Username = StringCipher.Encrypt(username, DataBaseHelper.GetSettingDB());
                        serialNote.Taken_HW_ID = StringCipher.Encrypt(hwID, DataBaseHelper.GetSettingDB());
                        serialNote.Status = StringCipher.Encrypt("USED", DataBaseHelper.GetSettingDB());
                        serialNote.ModiDate = DateTime.Now;
                        _dataManager.Update(serialNote);
                        _dataManager.Save();
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }
    }
}