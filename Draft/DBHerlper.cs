using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Draft
{
    public class DBHerlper
    {
        //数据库连接属性
        private static string strConn = "server=.;uid=sa;pwd=sasa;database=MySchool";

        /// 执行增加，删除，修改NonQuery语句
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int NonQuery(String sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                return comm.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return -1;
        }

        /// 执行返回单个值的语句（返回Int类型）
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Scalar(String sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                return (int)comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return -1;
        }

        /// 执行返回查询的语句
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader Reader(string sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                return comm.ExecuteReader(CommandBehavior.CloseConnection);//此处将关闭连接功能给reader对象（对象.Close()）
            }
            catch (Exception ex)
            {
                throw;
            }
            //此时不用关闭连接
            return null;
        }

        /// 执行断开式查询
        /// <summary>
        /// 此方法通过参数传入一个数据集,利用sqlClient接口为数据集插入一个表后在用返回值将此数据集返回
		/// 实现功能:为一个数据集增加一个表(并且不修改原有的数据)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ds">要插入数据表的数据集</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static DataSet Adapter(string sql, DataSet ds, string tableName)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
				if (ds.Tables[tableName]!=null)
				{
					ds.Tables[tableName].Clear();
				}
                adapter.Fill(ds, tableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
            return ds;
        }
    }
}
