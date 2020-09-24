using System;

namespace TestCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start test");

            //测试IsAssignableFrom
            //TestIsAssignableFrom.Start();
            //测试日期时间
            //TestDatetime.Start();
            //测试json
            //TestJson.Start();

            //测试集合
            //CollectionTest.TestHashSet.Start();
            CollectionTest.TestCollection.Start();

            Console.WriteLine("end test");
            Console.ReadLine();
        }
    }
}
