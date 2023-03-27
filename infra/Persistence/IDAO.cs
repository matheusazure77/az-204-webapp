using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Persistence
{
    public interface IDAO<T> where T:new()
    {
        List<T> ExcuteQuery(string sql, IDictionary<string, object>? parameters = null);
        int ExcuteNonQuery(string dml, IDictionary<string, object>? parameters = null);
    }
}
