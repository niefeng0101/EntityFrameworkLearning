using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLearn
{
    public class SQLHelper
    {
        //////////////////////////////////////////////////////////////////////////
        //第一二版
        /// <summary>
        /// 获取数据连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SntonContext"].ConnectionString;
        }

        /// <summary>
        /// 执行查询并将结果返回至DataTable中
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <param name="parameters">可能带的参数</param>
        /// <returns>返回一张查询结果表</returns>
        public static DataTable ExecuteDataTable(string strSql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
        }

        /// <summary>
        /// (重载)执行查询并将结果返回至DataTable中
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>返回一张查询结果表</returns>
        public static DataTable ExecuteDataTable(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
        }


        /// <summary>
        /// 执行对数据的增删改操作
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(string strSql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// (重载)执行对数据的增删改操作
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行查询并返回结果集中第一行第一列的值
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// (重载)执行查询并返回结果集中第一行第一列的值
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = strSql;
                    return cmd.ExecuteScalar();
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////
        //第三版新增
        /// <summary>
        /// (重载)向指定表中插入一行数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="cols">哈希表字段和值</param>
        /// <returns></returns>
        public static int Insert(string tableName, Hashtable cols)
        {
            //形式：insert into tablename(fileds)values(values);
            int num = 0;
            string strFileds = "(";
            string strValues = "(";
            //添加字段名和值
            foreach (DictionaryEntry item in cols)
            {
                if (num == 0)
                {
                    strFileds += item.Key.ToString();
                    strValues += item.Value.ToString();
                }
                else
                {
                    strFileds += "," + item.Key.ToString();
                    strValues += "," + item.Value.ToString();
                }

                num++;
            }
            strFileds += ")";
            strValues += ");";

            string strSql = "insert into " + tableName + strFileds + "values" + strValues;
            return SQLHelper.ExecuteNonQuery(strSql);
        }

        /// <summary>
        /// 根据DelbaTata获取列名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }


            return strColumns;
        }

        public static IList<T> ConvertToList<T>(DataTable dt) where T : new()
        {
            // 定义集合  
            List<T> ts = new List<T>();

            // 获得此模型的类型  
            Type type = typeof(T);
            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行   
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性  
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性  
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量    
                    //检查DataTable是否包含此列（列名==对象的属性名）      
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter    
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出    
                        //取值    
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性    
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中  
                ts.Add(t);
            }

            return ts;
        }
    }
}
