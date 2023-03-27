using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Persistence
{
    public class SimpleGenericDAO<T>: IDAO<T> where T : new()
    {
        private readonly IConfiguration _configuration;

        public SimpleGenericDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_configuration["MySQLConnection"]);
        }

        public int ExcuteNonQuery(string dml, IDictionary<string, object>? parameters = null)
        {
            int returnValue = 0;
            using (MySqlConnection conn = GetConnection())
            {                
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(dml, conn))
                {
                    if(parameters != null)
                    {
                        foreach (var parameter in parameters.Keys)
                        {
                            cmd.Parameters.AddWithValue(parameter, parameters[parameter]);
                        }
                    }
                    returnValue = cmd.ExecuteNonQuery();
                }

                conn.Close();
                return returnValue;
            }
        }

        public List<T> ExcuteQuery(string sql, IDictionary<string, object>? parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                var list = new List<T>();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var parameter in parameters.Keys)
                    {
                        cmd.Parameters.AddWithValue(parameter, parameters[parameter]);
                    }
                }
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    var columns = new List<string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(reader.GetName(i));
                    }
                    while (reader.Read())
                    {   
                        T item = new T();
                        Type itemYype = item.GetType();
                        foreach (var column in columns)
                        {
                            var property = itemYype.GetProperty(column);
                            if (property != null)
                            {
                                int columnOrdinal = reader.GetOrdinal(column);
                                property.SetValue(item, reader.GetValue(columnOrdinal));
                            }
                                
                        }
                        list.Add(item);
                    }
                }
                conn.Close();
                return list;
            }
        }
    }
}
