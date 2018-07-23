using POProject.BusinessLogic;
using POProject.BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyTable> list = MyTableBusiness.Retrieve().ToList();
            //list.ForEach(i => Console.WriteLine("{0}\t", i));
            Console.WriteLine("ID = " + list.FirstOrDefault().Id);
            Console.WriteLine("Nama = " + list.FirstOrDefault().Name);
            Console.ReadKey();
        }

        //list.ForEach(i => Console.Write("{0}\t", i));
    }
}
//=======
//﻿using POProject.BusinessLogic;
//using POProject.BusinessLogic.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestConnectionConsole
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<MyTable> list = MyTableBusiness.Retrieve().ToList();
//            list.ForEach(i => Console.Write("{0}\t", i));
//        }
	
	
//	//this is for test
//        //list.ForEach(i => Console.Write("{0}\t", i));
//    }
//}
//>>>>>>> cd0237e71f0393876739e190b35b728972fb23a4
