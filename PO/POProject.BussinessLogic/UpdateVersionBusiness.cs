using POProject.BusinessLogic.BusinessData;
using POProject.DataAccess;
using POProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace POProject.BusinessLogic
{
    public class UpdateVersionBusiness : IUpdateVersionBusiness
    {
        private readonly IUpdateVersionBusinessData _updateVersionBusinessData;

        public UpdateVersionBusiness(IUpdateVersionBusinessData updateVersionBusinessData)
        {
            _updateVersionBusinessData = updateVersionBusinessData;
        }

        public List<UpdateVersion> GetVersion()
        {
            return _updateVersionBusinessData.GetVersion();
        }
    }
}
