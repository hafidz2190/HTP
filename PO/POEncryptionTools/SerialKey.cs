using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace POAdministrationTools
{
    public static class SerialKey
    {
        public static string MakeKey(string user, string key)
        {
            string[] arrParam2 = key.Split('-');

            string firstLetter = user.Substring(0, 1);
            string secondLetter = user.Substring(1, 1);
            string thirdLetter = user.Substring(2, 1);
            string fourthLetter = user.Substring(3, 1);
            string fifthLetter = user.Substring(4, 1);
                        
            StringBuilder sb = new StringBuilder();
            sb.Append($"{arrParam2[0].Substring(0, 3)}{firstLetter}-");
            sb.Append($"{secondLetter}{RandomString(3)}-");
            sb.Append($"{arrParam2[1].Substring(0, 3) }{thirdLetter}-");
            sb.Append($"{fourthLetter}{RandomString(3) }-");
            sb.Append($"{RandomString(3) }{fifthLetter}");

            return sb.ToString();
        }

        public static bool ValidateKey(string user, string key, string serialKey)
        {
            var result = false;
            string[] arrKey = serialKey.Split('-'); //dwi-ganteng
            string keyUser = arrKey[0].Substring(arrKey[0].Length - 1, 1); //i
            keyUser += arrKey[1].Substring(0, 1);
            keyUser += arrKey[2].Substring(arrKey[2].Length - 1, 1);
            keyUser += arrKey[3].Substring(0, 1);
            keyUser += arrKey[4].Substring(arrKey[4].Length - 1, 1);

            if (string.Compare(user, keyUser) == 0)
            {
                string[] arrParam2 = key.Split('-');
                if ((arrKey[0].Substring(0, 3) == arrParam2[0].Substring(0, 3)) &&
                   (arrKey[2].Substring(0, 3) == arrParam2[1].Substring(0, 3)))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsIdMachine(string username, string urlApi, out string errMsg)
        {
            string cpuIdClient = string.Empty;
            errMsg = string.Empty;
            string cpuDB = string.Empty;
            cpuIdClient = RetrieveIDMachine();
            cpuDB = SenderTransaction.GetIdMachineByUsername(username, urlApi);

            if (cpuDB.ToUpper().Contains("ERROR"))
            {
                errMsg = cpuDB;
                return false;
            }

            if (string.Compare(cpuIdClient, cpuDB) == 0)
                return true;
            else
                return false;
        }

        public static string RetrieveIDMachine()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            {
                if (item.Properties["processorID"].Value != null)
                {
                    cpuInfo = item.Properties["processorID"].Value.ToString();
                    cpuInfo = cpuInfo.Replace("-", string.Empty);
                    break;
                }
            }

            mc = new ManagementClass("Win32_DiskDrive");
            moc = mc.GetInstances();
            foreach (ManagementObject item in moc)
            { 
                if (item.Properties["SerialNumber"].Value != null)
                {
                    string serialNumber = item.Properties["SerialNumber"].Value.ToString();
                    serialNumber = serialNumber.Replace("-", string.Empty);
                    cpuInfo += "-" + serialNumber;
                    break;
                }
            }

            return cpuInfo.Replace(" ", string.Empty);
        }

        public static string GenerateUser(List<string> lstUsr)
        {
            Random rnd = new Random();
            string randomTeks = string.Empty;
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            randomTeks = new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray());
            var isUserExists = lstUsr.FindAll(x => x.Equals(randomTeks)).ToList();
            while (isUserExists.Count > 0)
            {
                randomTeks = new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray());
                isUserExists = lstUsr.FindAll(x => x.Equals(randomTeks)).ToList();
            }

            return randomTeks;
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}



