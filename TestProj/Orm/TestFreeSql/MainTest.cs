using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFreeSql
{
    class MainTest
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
               //.UseConnectionString(FreeSql.DataType.SqlServer, "Data Source=.;Integrated Security=True;Initial Catalog=freesqlTest;Pooling=true;Max Pool Size=20")
               .UseConnectionString(FreeSql.DataType.MySql, "Data Source=127.0.0.1;Port=3306;User ID=root;Password=guanliyuan;Initial Catalog=test_freesql;Charset=utf8;SslMode=none;Max pool size=20")
               .UseAutoSyncStructure(true)
               .UseNoneCommandParameter(true)
               //.UseConfigEntityFromDbFirst(true)
               .Build();

        public static void Start()
        {
            //Test1();
            Test2();
            //Test3();
        }

        public static void Test1()
        {
            var c1 = fsql.Delete<Topic>().Where("1=1").ExecuteAffrows();
            fsql.Delete<Category>().Where("1=1").ExecuteAffrows();
            fsql.Delete<CategoryType>().Where("1=1").ExecuteAffrows();
            var items = new List<Topic>();
            for (var a = 0; a < 10; a++)
                items.Add(new Topic { Id = a + 1, Title = $"newtitle{a}", Clicks = a * 100, CategoryId = a });
            var t2 = fsql.Insert(items).ExecuteAffrows();
            Console.WriteLine($"插入行数：{t2}");

            var categories = new List<Category>();
            var categoryTypeId = 0;
            for (var i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    categoryTypeId = i;
                    fsql.Insert(new CategoryType() { Id = categoryTypeId, Name = $"category_type_{categoryTypeId}" }).ExecuteAffrows();
                }
                categories.Add(new Category { Id = i, Name = $"category_{i}", ParentId = categoryTypeId });
            }
            fsql.Insert(categories).ExecuteAffrows();
        }

        public static void Test2()
        {
            var q1 = fsql.Select<Topic>();
            var result = q1.From<Category>((t1, t2) => t1.InnerJoin(t => t.CategoryId == t2.Id))
                           .Where((t1, t2) => t2.ParentId == 2)
                           .ToList();
            Console.WriteLine(result.Count);

            var result2 = q1.LeftJoin<Category>((t1, t2) => t1.CategoryId == t2.Id)
                         .Where<Category>(t2 => t2.ParentId == 2)
                         .ToList();
            Console.WriteLine(result2.Count);
        }

        public static void Test3()
        {
            var q1 = fsql.Select<Topic>();
          
        }
    }

    class Topic
    {
        [Column(IsIdentity = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Clicks { get; set; }
        public DateTime CreateTime { get; set; }

        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ParentId { get; set; }
        public CategoryType Parent { get; set; }
        public List<Topic> Topics { get; set; }
    }
    class CategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
