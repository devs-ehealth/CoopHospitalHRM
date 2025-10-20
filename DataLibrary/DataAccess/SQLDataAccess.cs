using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace LIS_WEB.DataLibrary.DataAccess
{
    public class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName = "Inventory")
        {
            string s = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return s;
        }

        public static string GetConnectionLIS(string connectionName = "LIS")
        {
            string s = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return s;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        public static List<T> LoadData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static List<T> LoadDataLIS<T>(string sql)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionLIS()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }


        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }

        public static int SaveData(string sql)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql);
            }
        }

        public static int SaveDataLIS(string sql)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionLIS()))
            {
                return connection.Execute(sql);
            }
        }

        public static int UpdateData(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                try
                {
                    int x = connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
                    return x;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static int UpdateData(string sql)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                try
                {
                    int x = connection.Execute(sql);
                    return x;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public static int ExecSP<T>(string sql, T data)
        {
            using (IDbConnection connection = (IDbConnection)new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data, commandType: CommandType.StoredProcedure);
            }
        }
    }
}