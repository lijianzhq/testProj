using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestCoreConsole
{
    class TestObj
    {
        public String A { get; set; }
        public String B { get; set; } = "zhuhaiqing";

        public String[] Array { get; set; } = new string[] { "1", "2" };
        public List<String> Array2 { get; set; } = new List<String> { "4", "6" };
    }

    class TestObj2
    {
        public TestObj TestObj { get; set; } = new TestObj();
        public String C { get; set; } = "lijian";
        public Int32 NumberValue { get; set; } = 101;
    }

    class TestObj3
    {
        public TestObj2 TestObj { get; set; } = new TestObj2();
        public String DD { get; set; } = "zhumengxiao";
    }


    class TestJson
    {
        public static void Start()
        {
            Test1();
        }

        public static void Test1()
        {
            var obj = new TestObj3();
            var dic = FlattenObj(obj);
        }

        public static Dictionary<String, Object> FlattenObj(Object obj)
        {
            var jObj = JObject.FromObject(obj);
            var properties = jObj.Properties().ToList();
            var values = jObj.PropertyValues().ToList();
            var dic = new Dictionary<String, Object>();
            foreach (var p in properties)
            {
                var token = p.Value;
                switch (token.Type)
                {
                    case JTokenType.None: break;
                    case JTokenType.Array:
                        dic.Add(p.Name, token.Values<Object>().ToList());
                        break;
                    case JTokenType.Constructor: break;
                    case JTokenType.Property: break;
                    case JTokenType.Comment: break;
                    case JTokenType.Integer:
                        dic.Add(p.Name, token.Value<Int32>());
                        break;
                    case JTokenType.Float:
                        dic.Add(p.Name, token.Value<Single>());
                        break;
                    case JTokenType.String:
                        dic.Add(p.Name, token.Value<String>());
                        break;
                    case JTokenType.Boolean:
                        dic.Add(p.Name, token.Value<Boolean>());
                        break;
                    case JTokenType.Null:
                        dic.Add(p.Name, null);
                        break;
                    case JTokenType.Undefined: break;
                    case JTokenType.Date:
                        dic.Add(p.Name, token.Value<DateTime>());
                        break;
                    case JTokenType.Raw: break;
                    case JTokenType.Bytes: break;
                    case JTokenType.Guid: break;
                    case JTokenType.Uri: break;
                    case JTokenType.TimeSpan:
                        dic.Add(p.Name, token.Value<TimeSpan>());
                        break;
                    case JTokenType.Object:
                        var innerDic = FlattenObj(token.Value<Object>());
                        foreach (var item in innerDic)
                        {
                            dic.Add(item.Key, item.Value);
                        }
                        break;
                }
            }
            return dic;
        }
    }
}
