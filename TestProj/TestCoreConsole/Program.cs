using System;

namespace TestCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start test");

            //测试IsAssignableFrom
            TestIsAssignableFrom.Start();

            Console.WriteLine("end test");
            Console.ReadLine();
        }
    }
}
