using Microsoft.Practices.Unity;
using POProject.Builder;
using POProject.BusinessLogic;
using POProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;

namespace TestEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            IDictionary<string, object> mainOjectMap;

            MainObjectBuilder mainObjectBuilder = new MainObjectBuilder(container);
            mainOjectMap = mainObjectBuilder.BuildMainObject();

            IBankBusiness bankBusiness = container.Resolve<IBankBusiness>();

            List<Bank> banks1 = bankBusiness.RetrieveDataBank(null);
            List<Bank> banks2 = bankBusiness.RetrieveDataBank("1");

            string sqlQuery = "select * from banks where kode_bank = @kode_bank";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@kode_bank", "2");

            List<Bank> banks3 = bankBusiness.RetrieveDataBankSqlQuery(sqlQuery, parameters);

            foreach (Bank b in banks1)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2}", b.Kode_Bank, b.Nama_Bank, b.Username));
            }

            Console.WriteLine("=========================");

            foreach (Bank b in banks2)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2}", b.Kode_Bank, b.Nama_Bank, b.Username));
            }

            Console.WriteLine("=========================");

            foreach (Bank b in banks3)
            {
                Console.WriteLine(string.Format("{0} | {1} | {2}", b.Kode_Bank, b.Nama_Bank, b.Username));
            }

            Console.ReadKey();
        }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = SqlProviderServices.Instance;
        }
    }
}
