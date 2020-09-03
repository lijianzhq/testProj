using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TestDapper
{
    public class MySqlTest
    {
        public static void Start()
        {
            using (var conn = OpenCurrentDbConnection())
            {
            }
        }

        /// 返回连接实例        
        private static IDbConnection dbConnection = null;

        /// <summary>
        /// 创建数据库连接对象并打开链接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenCurrentDbConnection()
        {
            if (dbConnection == null)
            {
                dbConnection = new SqlConnection(@"Server=127.0.0.1;Database=test_db;Uid=root;Pwd=guanliyuan");
            }
            //判断连接状态
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            return dbConnection;
        }
    }
}
