using POAdministrationTools;
using System;

namespace POProject.DataAccess
{
    public class DataBaseHelper
    {
        private static string DataBaseName;
        private static string UserID;
        private static string Password;
        private static string SettingDB;
        public static CommandAdapter.OracleCmdBuilder CreateOracleCommand()
        {
            SettingDB = "SURABAYA";
            DataBaseName = StringCipher.Decrypt("Ib7bXwZd0KDcyYEPbYUohthzLIdGCh3mNey7k0vbEbjKlGwvmJySSIjJT4on/ekq56ErSWNR6OMcVTpOPlYMKwooNERfDVXwoKzKNB4mXCWtdpaG1S8cNPQFfUp7RQtM2Vo2eEOoB2ps2BrCIll1ioC/H4OE3OiAUZUrvDScpPsww4v+1g8ZmWeXo80/t6NpctjTVNtAvgeS1VOdywjSpTLcWC0/AQmtPPVfxhBApLEsDFQiAmgiQUVj5FcI4mCsJT8Jd5RfpO2Ct+n5gAbWxjAQKjy5ULMJdwS6rHwCTZ3Z6UNztd1WoORRH9MVi7eowVsCBRGwoG9XmYpaLWDPQ/u8kSk3R2fU+AVSDFK6PXs=", SettingDB);            
            UserID = StringCipher.Decrypt("GNF/7xwUw2sCMQPzcDUqjlxRppyt0odTKpvzOvcxVP9BIfOTJEkyDLld3Db8CE/p3TQsp8yOjsrZ5eitYlHZtooT1Rink98yU40x3po5rOEOgztXIyMHnRX2Txz8lYxR+av9QFOQzdtRRvP3hobeS5IRRoEZ2JGQR30XZ/6WQo/s+kbB7dO/3DfacE2tRDGWSdc0lGPiGHFtKJsywK8iiYXwB3BYfZJC+QEdTp96d5VY0IqqLPmqpjZIn812v2WcSy9Suc03NwjQ5aCnheD6NM2QtwRHm9KbX8KzE1SV66rwNz5YhWSjGGrIy4qstMl/YVQG38Kscf1K36Z67HdANBnUccMOw9RHlptZqbiMuF8=", SettingDB);
            Password = StringCipher.Decrypt("stT2rZoFzx2x5OMxPFifIRB1gIqUa40+jW4/JtZBt6DmslCgWecgzPA1BEs11wGseRD7GKTxLA5Bsj92asUr3ieQuslypE1VPj6LW5RiZBzzg/P7NloKjI51hiLiCCjF2EifjBU9hKj5ps008Dk6lkJn2JMnRc1uUHQbiEbQcGFSMbLYSSuWAP3UTcxwUE6de7jownKd24MoeIcqH7xzqxtBjgOVx9Ur6BPYy10SSc5JYD8TQaJTfb3H2wIbkJw4Z3pXWHh682wCaBZQNVuzt/yCM70OYdsarWfI68NRsUUNAb/FvcF3/9hJVbLrzMPsm/NcV4GeffG+snEB0bPP/NTtJRKDUMRazihSwSML/jY=", SettingDB);
            return new CommandAdapter.OracleCmdBuilder(DataBaseName, UserID, Password);
        }

        public static CommandAdapter.OracleCmdBuilder CreateOracleCommandElang()
        {
            SettingDB = "SURABAYA";
            DataBaseName = StringCipher.Decrypt("jUj/RSRG3qjBhkV1rc+x1/eN+VaJSRxcTCVZihM4lx/8d3oR8PQMrH1lfKcNhMc0oq0LntK+sc/Zn6nnrkRCtPvCGWZ2TbWnwrXFupI6xDuyH8g7TfTq9EYyYA2Uj/wVrN9K5JcXmjSeCA+wzilz+4QOG0Lzrk+eNJPyVCK6hcbslFNdxsbrgmo2r7ce+u7dJdxJkljcM1eKe9SIUpGITBTFA1YSk0RxFSjeAvqoi4A14Z9Le/QLH35usUSONN7kEHNkj9e09SFf3fMPKsy7/1lw+tCMB+g7zmT/yMNpAdp/K3CSy85EdV+Yz/gQw+mSeFDG1vdZLh9EQUxnCFxWpeq4GyKM1KADkC6bExkwobQ=", SettingDB);
            UserID = StringCipher.Decrypt("UVJH8IX2l0jorBD5ZWEBPJBNob2IbCxxb3mYETwxJwdS8PW6DNuC9ugsnm+yTXVnuAy9QtasrieapurE+Jt/eIZ4INDhvnX0c4YOYTxDmz2muXF8n+Yqxp4/tL306Kq50NRuplZg/cF4z/fWITPmdpgjniM58G6w1CVPzkbz66aRc74FTWt933VsWrFAe+esLr1BJMt/d3OPfcyVGTeY4/fcJIw1yaS9+onPR9wt9XldDzsAz5F0CPg2wt8DTFwAXbUkJRsssM0PIzDJ5W7rmTLo0NzTrJcTH9M0iJvrMvXXJiYE1rJ7f3/IEJDV5tvYJc+gUdf9dSoOV6iMWRpTyDM2qhuyrS8ydrPFC4trxJg=", SettingDB);
            Password = StringCipher.Decrypt("vr9yrqJKMQjWkRrKPZF4QYG01c/asTFvw24XN7dMmLSxgTv6sjb5qHu0gc3FcrvhMcRNBl8ROSGTdEWu5RIcGP1LvFZAbN684If1IrEMQ/cscGAp6xk+AulECJcU9zNKiReOZuBo85d6bCSfhKmqBHjVafEv6su4D2EuEjHhtqCkLJzMQdUTlzlAd9LW9NOntmaCKZphVrCqZrV0lVx3MGSlRxDTsmO0Pw47rr+d8Sn0xLAtLoAcovx25pHRLo0mPqGX+x1uiKW8yKeqzyhY4eKS1gF0NMWEGnNp4aT2nekyWtSQPp/Lc276LZrvbsdE2O85YCPTmQb0t1rckvMIDXu5gUcB4Yo7Fg2geZYzzZc=", SettingDB);
            return new CommandAdapter.OracleCmdBuilder(DataBaseName, UserID, Password);
        }

        public static CommandAdapter.OracleCmdBuilder CreateOracleCommandBonang()
        {
            SettingDB = "SURABAYA";
            DataBaseName = StringCipher.Decrypt("CrUJV8Wry0jTb1mYNRzInua5afhK06i+RTQyZtOVrgJDrJBLddo+HLCD8ait3vMSX9ViW19Ezu+YfgtzG0nxhmi0w/QBSv8x4mVAIJ6dkmI3oe7IfxmkmTWnfUFsS9manwUQvgABNa8QnSwXgyt3YM4JcHEIciT2XQrlvOHTGGRqnNSlOU+t0IIkRUX4/0hKSdKm9f/Lnn6JehHoMcH37qlNlkVHch6DTP6/twxV5s1xHAXjSM0156NZmiIOJZQ3WpGRtF19OpBIVmEIkrPsQ/6k7k0zH/HXA6nycdmjzIN5cjMryXcc4y/kG5/mM3uOWRKsgNy9nEFmVIiCetoLuzNgoN6ThZfpwCHgiET0ZHw=", SettingDB);
            UserID = StringCipher.Decrypt("CeJ3FciOlUBKOJzOTiqVbeifQ+NwbuiZWDIJUb+CqxQ7GJ80vntRX1G/jhN050YItwR3eD2SqEBRtkIkJAn1+Dsgf7xifqK3B+Ue4zOhNZMsOMdcFxrPi8pkXTKLO5zMod+cobMaxmFmotel8WvAEG+nw0rYrktGWfrDS8pgZqDlkngq6NHaN53kGqyQv700ZcZYzC4MHoexWivJdAi9puya5tm9RwHJY4ziIWbRW1n2lghCPIOk1CHtZqhXkCE4rLKhgZtu3gMfrtPeig09rZWSXt7AHdOwqH+mxdfUpACmp0D2kdijQM2MudZJI54VJFfDz3+d/d76Z/wZUF0g3UPEXBn3x/1dCavL3pYVWNg=", SettingDB);
            Password = StringCipher.Decrypt("l3Etdl9wwzPgCtCqRRsy+tL0KLhgJiQvAvcvn6xA9t6wxWO+QZn3msvVUw95oCRa4z32sXH8YUGy/VkEh0lcmUHdAvXKun1+mWRV1ZxrL9taugXVdUbZW/Oq3XUsIrLx1qeg0+eWtiv8KModwuy3BpcFlruo0kHRDi/q1X8hL9VSidP6IexBsO4YzUId4YgisNXvOabe9FTuIQkfTmTjMKsVKrllGkxogxcAqvk/UGDXx8rDGRlnzXaUWTjom4LJ8E+auVQA+s9pZnwybwqhoYjssSgT1H/aWu3aMq29qQMs2qZaeQlgI1w1YMDLy8O8YLOW0li2ZicttIIAcq23APKKDm425JDPMz3WaU8FKbM=", SettingDB);
            return new CommandAdapter.OracleCmdBuilder(DataBaseName, UserID, Password);
        }

        public static CommandAdapter.MsAccessCmdBuilder CreateMsAccessCommand()
        {
            return new CommandAdapter.MsAccessCmdBuilder("", "");
        }
    }
}
