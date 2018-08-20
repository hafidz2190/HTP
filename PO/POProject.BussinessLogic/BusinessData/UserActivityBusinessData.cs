using System;
using System.Collections.Generic;
using System.Linq;
using POProject.DataAccess.Persistance;
using POProject.Model;

namespace POProject.BusinessLogic.BusinessData
{
    public class UserActivityBusinessData : IUserActivityBusinessData
    {
        private readonly IDataManager _dataManager;
        private readonly IDataManagerDataTable _dataManagerDataTable;

        public UserActivityBusinessData(IDataManager dataManager, IDataManagerDataTable dataManagerDataTable)
        {
            _dataManager = dataManager;
            _dataManagerDataTable = dataManagerDataTable;
        }

        public DateTime GetLastErrorDate(string username)
        {
            UserTransaction userTransaction = _dataManager.GetFirst<UserTransaction>((e => e.Username == username), (q => q.OrderByDescending(e => e.Tanggal)));

            return userTransaction == null ? DateTime.Now.AddDays(-1) : userTransaction.Tanggal;
        }

        public string GetUrlApi()
        {
            UserApiUrl userApiUrl = _dataManager.GetOne<UserApiUrl>();
            string apiUrl = userApiUrl == null ? "" : userApiUrl.url_api;

            return apiUrl;
        }

        public bool InsertUserActivity(string username, string ipAddress, DateTime activityDate, bool status, string keterangan)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    _dataManager.Create(new UserActivity()
                    {
                        Username = username,
                        Ip_Address = ipAddress,
                        Activity_Date = activityDate,
                        Status_Error = status,
                        Keterangan = keterangan
                    });

                    _dataManager.Save();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public bool InsertUserTempError(string username, DateTime activityDate)
        {
            bool result = true;

            using (var transaction = _dataManager.BeginTransaction())
            {
                try
                {
                    _dataManager.Create(new UserTempError()
                    {
                        Username = username,
                        tanggal_error = activityDate
                    });

                    _dataManager.Save();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public List<UserActivity> RetrieveUserActivity(string username)
        {
            return _dataManager.Get<UserActivity>((e => e.Username == username)).ToList();
        }
    }
}
