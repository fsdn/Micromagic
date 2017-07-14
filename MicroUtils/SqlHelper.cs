using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    public class SqlHelper
    {
        #region 私有变量

        private string connStr;

        private enum DBType
        {
            SQLServer,
            Oracle
        }

        #endregion

        /// <summary>
        /// 数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public SqlHelper(string connectionString)
        {
            connStr = connectionString;
        }

        #region SqlScalar

        /// <summary>  
        /// 查询结果集中第一行第一列的值  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <returns>第一行第一列的值</returns>  
        public object SqlScalar(string sql)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }

        /// <summary>  
        /// 查询结果集中第一行第一列的值  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="sqlParameters">参数数组</param>  
        /// <returns>第一行第一列的值</returns>  
        public object SqlScalar(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    SqlCommandParameters(cmd, sqlParameters);
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }

        #endregion

        #region SqlReader

        /// <summary>  
        /// 创建数据读取器  
        /// </summary>  
        /// <param name="safeSql">T-Sql语句</param>  
        /// <returns>数据读取器对象</returns>  
        public SqlDataReader SqlReader(string sql)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
        }

        /// <summary>  
        /// 创建数据读取器  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="sqlParameters">参数数组</param>
        /// <returns>数据读取器</returns>  
        public SqlDataReader SqlReader(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, Connection))
                {
                    SqlCommandParameters(cmd, sqlParameters);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
        }

        #endregion

        #region SqlTable

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataTable 
        /// </summary>
        /// <param name="sql">T-Sql语句</param>
        /// <returns></returns>
        public DataTable SqlTable(string sql)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (DataSet ds = new DataSet())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataTable 
        /// </summary>
        /// <param name="sql">T-Sql语句</param>
        /// <param name="sqlParameters">参数数组</param>
        /// <returns></returns>
        public DataTable SqlTable(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (DataSet ds = new DataSet())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlCommandParameters(cmd, sqlParameters);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }

        /// <summary>  
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable  
        /// </summary>  
        /// <param name="type">命令类型(T-Sql语句或者存储过程)</param>  
        /// <param name="sql">T-Sql语句或者存储过程的名称</param>  
        /// <param name="sqlParameters">参数数组</param>  
        /// <returns>结果集DataTable</returns>  
        public DataTable SqlTable(CommandType type, string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                using (DataSet ds = new DataSet())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        cmd.CommandType = type;
                        SqlCommandParameters(cmd, sqlParameters);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }

        #endregion

        #region SqlExecute

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回bool
        /// </summary>
        /// <param name="sql">T-Sql语句</param>
        /// <returns></returns>
        public bool SqlExecute(string sql)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                SqlTransaction trans = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        cmd.Transaction = trans;
                        int rows = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return rows > 0;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回bool 
        /// </summary>
        /// <param name="sql">T-Sql语句</param>
        /// <param name="sqlParameters">参数数组</param>
        /// <returns></returns>
        public bool SqlExecute(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                SqlTransaction trans = Connection.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Connection))
                    {
                        cmd.Transaction = trans;
                        SqlCommandParameters(cmd, sqlParameters);
                        int rows = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return rows > 0;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 批量执行数据库连接对象的命令,返回bool 
        /// </summary>
        /// <param name="sqlList"></param>
        /// <param name="sqlParametersList"></param>
        /// <returns></returns>
        public bool SqlExecute(List<string> sqlList, List<SqlParameter[]> sqlParametersList)
        {
            using (SqlConnection Connection = new SqlConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                SqlTransaction trans = Connection.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        string sql = sqlList[i];
                        SqlParameter[] sqlParameters = sqlParametersList[i];
                        using (SqlCommand cmd = new SqlCommand(sql, Connection))
                        {
                            cmd.Transaction = trans;
                            SqlCommandParameters(cmd, sqlParameters);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// SqlCommand参数的赋值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="sqlParameters"></param>
        private void SqlCommandParameters(SqlCommand cmd, params SqlParameter[] sqlParameters)
        {
            cmd.Parameters.Clear(); // 先清空
            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                if (sqlParameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value. 
                    if (sqlParameter.Value == null && (sqlParameter.Direction == ParameterDirection.Input || sqlParameter.Direction == ParameterDirection.InputOutput))
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(sqlParameter);
                }
            }
        }

        #endregion
    }
}
