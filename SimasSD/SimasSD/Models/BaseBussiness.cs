using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace SimasSD.Models
{
    public abstract class BaseBussiness
    {
        protected SqlConnection sqlcon { get; set; }


        public BaseBussiness()
        {
            try
            {
                sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SimasConnStr"].ConnectionString.ToString());
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
        public virtual IList<T> GetData<T>(string sSql) where T : class, new()
        {
            List<T> list = new List<T>();

            using (sqlcon)
            {
                list = sqlcon.Query<T>(sSql).ToList();
            }

            return list;
        }

        public string GetID(string tableName)
        {
            string Id = "";
            string _query = string.Format("SELECT dbo.GenerateEmpyID('{0}') as Id", tableName);
            using (sqlcon)
            {
                try
                {
                    var x = sqlcon.Query(_query);
                }
                catch(Exception ex)
                {

                }
               
            }

            return Id;
        }

        public IList<T> GetDataWithParam<T>(string sSql, T obj) where T : class, new()
        {
            List<T> list = new List<T>();

            using (sqlcon)
            {
                list = sqlcon.Query<T>(sSql, obj).ToList();
            }

            return list;
        }

        public T GetDataByID<T>(string sSql, string _id) where T : class, new()
        {
            T obj = new T();

            using (sqlcon)
            {
                obj = sqlcon.Query<T>(sSql, new { id = _id }).FirstOrDefault();
            }

            return obj;
        }
        public virtual int Insert<T>(string sSql, T obj) where T : class, new() {
            int rowAffected = 0;
            using (sqlcon)
            {
                rowAffected = sqlcon.Execute(sSql, obj);
            }
            return rowAffected;
        }

        public virtual int Insert<T>(string sSql, T obj, DynamicParameters param) where T : class, new()
        {
            return 0;
        }

        public virtual int Update<T>(string sSql, T obj) where T : class, new()
        {
            int rowAffected = 0;
            using (sqlcon)
            {
                rowAffected = sqlcon.Execute(sSql, obj);
            }
            return rowAffected;
        }

        public virtual int Update<T>(string sSql, T obj, DynamicParameters param) where T : class, new()
        {
            
            return 0;
        }

        public virtual int Delete<T>(string sSql, T obj) where T : class, new()
        {
            int rowAffected = 0;
            try
            {
                using (sqlcon)
                {
                    rowAffected = sqlcon.Execute(sSql, obj);
                }
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return rowAffected;
        }
    }
}