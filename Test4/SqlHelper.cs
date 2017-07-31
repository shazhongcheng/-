using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Test4
{
    class SqlHelper
    {
        static string Path = @"data.db";
        /// <summary>
        /// ---创建数据库
        /// </summary>
        public static void CreateDB()
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            cn.Open();
            cn.Close();
        }

        /// <summary>
        /// ---添加表
        /// </summary>
        public static void CreateClientTable()
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS Client([Id] [INTEGER] IDENTITY(1000,1) PRIMARY KEY,[name][nvarchar](50) NOT NULL,[telephone] [varchar] (200) NOT NULL,[address] [nvarchar] (200) NOT NULL)";
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        /// <summary>
        /// ---添加表
        /// </summary>
        public static void CreateRelishTable()
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS Relish([Id] [INTEGER] IDENTITY(1000,1) PRIMARY KEY,[name][nvarchar](50) NULL,[unit] [nvarchar] (50) NULL,[standard] [nvarchar] (50) NULL,[number] [int] NULL,[priceone] [decimal](18, 2) NULL,[note] [nvarchar] (200) NULL)";
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        /// <summary>
        /// ---添加表
        /// </summary>
        public static void CreatePartTable()
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS Part([Id] [INTEGER] IDENTITY(1000,1) PRIMARY KEY,[name][nvarchar](50) NOT NULL,[telephone] [varchar] (200) NOT NULL,[address] [nvarchar] (200) NOT NULL)";
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        /// <summary>
        /// 1.执行无返回值Sql命令
        /// </summary>
        /// <param name="sql">Sql命令</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                cmd.CommandText = sql;
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                return cmd.ExecuteNonQuery();
            }
            cn.Close();
            return 0;
        }

        /// <summary>
        /// 2.执行查询,返回单个值的方法
        /// </summary>
        /// <param name="sql">Sql命令</param>
        /// <returns>返回查询的单个值</returns>
        public static object ExecuteScalar(string sql)
        {
            using (SQLiteConnection cn = new SQLiteConnection("data source=" + Path))
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }              
                }
                return null;
               
            }
        }

        /// <summary>
        /// 3.执行查询,返回多行,多列的方法
        /// </summary>
        /// <param name="sql">Sql命令</param>
        /// <returns>SQLiteDataReader</returns>
        public static SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + Path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = sql;
                    //cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                    try
                    {
                        cn.Open();
                        //关闭reader的时候 同时关闭Connection
                        return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    catch
                    {
                        cn.Close();
                        cn.Dispose();
                        throw;
                    }
                }   
            }
            return null;
        }
    }
}
