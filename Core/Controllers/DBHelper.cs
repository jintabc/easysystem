using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EasySystem.Core.Controller
{
    public class DBHelper
    {
        private DBHelper()
        {

        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        //public static readonly string connStringold = ConfigurationManager.ConnectionStrings["oldconnectionstring"].ConnectionString;
        public static readonly string connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        /// <summary>
        /// 执行命令,返回受影响的行数
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            int retVal;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdtype;

                if (parms != null)
                {
                    //添加参数   
                    cmd.Parameters.AddRange(parms);
                }

                conn.Open();
                retVal = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return retVal;
        }

        /// <summary>
        /// 执行命令, 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="cmdtype"></param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, CommandType cmdtype)
        {
            int retVal;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdtype;

                conn.Open();

                retVal = cmd.ExecuteNonQuery();
                conn.Close();
            }


            return retVal;
        }

        /// <summary>
        /// 执行命令, 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            int retVal;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                retVal = cmd.ExecuteNonQuery();

                conn.Close();
            }
            return retVal;
        }


        /// <summary>
        /// 执行命令,返回第一行第一列
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回第一行第一列,不存在返回Null</returns>
        public static object ExecuteScalar(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            object retVal;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdtype;

                if (parms != null)
                {
                    //添加参数   
                    cmd.Parameters.AddRange(parms);
                }

                conn.Open();
                retVal = cmd.ExecuteScalar();
                conn.Close();
            }
            return retVal == DBNull.Value ? null : retVal;
        }

        /// <summary>
        /// 执行命令,返回第一行第一列
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回第一行第一列,不存在返回Null</returns>
        public static object ExecuteScalar(string cmdText, CommandType cmdtype)
        {
            object retVal;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = cmdtype;

                conn.Open();
                retVal = cmd.ExecuteScalar();

                conn.Close();
            }
            return retVal == DBNull.Value ? null : retVal;
        }

        /// <summary>
        /// 执行命令,返回第一行第一列
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <returns>返回第一行第一列,不存在返回Null</returns>
        public static object ExecuteScalar(string cmdText)
        {
            object retVal;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                retVal = cmd.ExecuteScalar();
                conn.Close();
            }

            return retVal == DBNull.Value ? null : retVal;
        }

        /// <summary>
        /// 执行命令,返回一个数据读取器,注意使用完毕后关闭读取器
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回一个数据读取器</returns>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            SqlDataReader reader;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            if (parms != null)
            {
                //添加参数   
                cmd.Parameters.AddRange(parms);
            }

            conn.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        ///  执行命令,返回一个数据读取器,注意使用完毕后关闭读取器
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回一个数据读取器</returns>
        public static SqlDataReader ExecuteReader(string cmdText, CommandType cmdtype)
        {
            SqlDataReader reader;

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            conn.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        ///  执行命令,返回一个数据读取器,注意使用完毕后关闭读取器
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <returns>返回一个数据读取器</returns>
        public static SqlDataReader ExecuteReader(string cmdText)
        {
            SqlDataReader reader;

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// 执行命令,返回DataTable
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = cmdtype;

                if (parms != null)
                {
                    apt.SelectCommand.Parameters.AddRange(parms);
                }

                apt.Fill(dt);
                conn.Close();
            }
            return dt;
        }


        /// <summary>
        /// 执行命令,返回DataTable
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTableOld(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = cmdtype;

                if (parms != null)
                {
                    apt.SelectCommand.Parameters.AddRange(parms);
                }

                apt.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行命令,返回DataTable
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string cmdText, CommandType cmdtype)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = cmdtype;
                apt.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行命令,返回DataTable
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string cmdText)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = CommandType.StoredProcedure;
                apt.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行命令,返回第一行,不存在返回Null
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="parms">需要的参数</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回第一行,不存在返回Null</returns>
        public static DataRow ExecuteFirstRow(string cmdText, SqlParameter[] parms, CommandType cmdtype)
        {
            DataRow row = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = cmdtype;

                if (parms != null)
                {
                    apt.SelectCommand.Parameters.AddRange(parms);
                }
                apt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }
                conn.Close();
            }
            return row;
        }

        /// <summary>
        /// 执行命令,返回第一行,不存在返回Null
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <param name="cmdtype">如何解释命令字符串</param>
        /// <returns>返回第一行,不存在返回Null</returns>
        public static DataRow ExecuteFirstRow(string cmdText, CommandType cmdtype)
        {
            DataRow row = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = cmdtype;
                apt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }
                conn.Close();
            }
            return row;
        }

        /// <summary>
        /// 执行命令,返回第一行,不存在返回Null
        /// </summary>
        /// <param name="cmdText">查询的文本</param>
        /// <returns>返回第一行,不存在返回Null</returns>
        public static DataRow ExecuteFirstRow(string cmdText)
        {
            DataRow row = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter apt = new SqlDataAdapter(cmdText, conn);
                apt.SelectCommand.CommandType = CommandType.StoredProcedure;
                apt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }
                conn.Close();
            }
            return row;
        }

    }

}
