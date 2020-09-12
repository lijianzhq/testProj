using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoreConsole.CollectionTest
{
    class SetItem
    {
        public String Name;

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    var u = obj as SetItem;
        //    if (u == null) return false;
        //    return u.Name == this.Name;
        //}
    }

    static class TestHashSet
    {
        public static T CopyAs<T>(this Object obj)
        {
            if (obj == null) return default(T);
            var objStr = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(objStr);
        }

        /// <summary>
        /// create by jianl
        /// 分页简化版
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">集合</param>
        /// <returns></returns>
        public static void RemoveAll<T>(this HashSet<T> targetCollection, Func<T, Boolean> funck)
        {
            if (targetCollection == null || funck == null) return;
            //var enumerator = targetCollection.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    if (funck(enumerator.Current))
            //        targetCollection.Remove(enumerator.Current);
            //}
            //foreach(var item in targetCollection)
            //{
            //    if (funck(item))
            //        targetCollection.Remove(item);
            //}
            var copyCol = targetCollection.CopyAs<HashSet<T>>();
            foreach (var item in copyCol)
            {
                if (funck(item))
                    targetCollection.Remove(item);
            }
        }


        public static void Start()
        {
            //Add();
            //Add2();
            Test1();
        }

        static void Test1()
        {
            var set = new HashSet<String>();
            set.Add("lijian");
            set.Add("lijian");
            set.Add("zhq");

            set.RemoveAll(it => it == "lijian");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        static void Add()
        {
            var set = new HashSet<String>();
            set.Add("lijian");
            set.Add("lijian");
            set.Add("zhq");
            Console.WriteLine(set.Count);
        }

        static void Add2()
        {
            var set = new HashSet<SetItem>();
            set.Add(new SetItem() { Name = "lijian" });
            set.Add(new SetItem() { Name = "lijian" });
            set.Add(new SetItem() { Name = "zhq" });
            Console.WriteLine(set.Count);
        }
    }
}
