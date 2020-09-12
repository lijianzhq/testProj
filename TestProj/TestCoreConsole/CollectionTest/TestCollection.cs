﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TestCollection
    {
        public static void Start()
        {
            //Test4();
            //Test5();
            //TestOrderBy();
            TestExcept();
        }

        /// <summary>
        /// 测试互斥集合
        /// </summary>
        public static void TestExcept()
        {
            var list1 = new List<String>() { "1", "2", "3" };
            var list2 = new List<String>() { "3" };
            var list3 = list1.Except(list2);
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        public static void TestOrderBy()
        {
            var str = new String[] { "v1.00", "v1.10", "v1.20", "v1.19", "v1.21", "v1.12", "v1.09", "v1.30", "v1.31", "v1.32", "v2.00" };
            foreach (var item in str.OrderBy(it => it))
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 测试遍历指针
        /// </summary>
        public static void Test5()
        {
            var data = new Func<IEnumerable>(() =>
            {
                return new List<Int32>() { 0 };
            }).Invoke();
            var enumerator = data.GetEnumerator();
            var moveNext = enumerator?.MoveNext();
            Console.WriteLine(enumerator.Current);
        }

        /// <summary>
        /// 测试keypari不能为空的现象
        /// </summary>
        public static void Test4()
        {
            var dic = new Dictionary<String, Int32>();
            var keyPair = dic.SingleOrDefault(it => it.Key == "aaa");
            Console.WriteLine(keyPair.Value);
        }

        /// <summary>
        /// 测试hasset是否可以加入相同的值
        /// </summary>
        public static void Test3()
        {
            var set = new HashSet<String>();
            set.Add("1");
            set.Add("1");
            Console.WriteLine(set.Count);
        }

        /// <summary>
        /// 测试逆变和协变
        /// </summary>
        public static void Test1()
        {
        }

        /// <summary>
        /// 测试逆变和协变
        /// </summary>
        /// <param name="childList"></param>
        public static void Test2()
        {
        }
    }
}
