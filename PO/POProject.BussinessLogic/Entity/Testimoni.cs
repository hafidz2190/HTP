using System;

namespace POProject.BusinessLogic.Entity
{
    public class Testimoni
    {
        //USERNAME, COMMEND, CREATE_DATE, IS_SHOW
        public string Username { get; set; }
        public string Commend { get; set; }
        public DateTime Create_Date { get; set; }
        public bool Is_Show { get; set; }
    }
}
