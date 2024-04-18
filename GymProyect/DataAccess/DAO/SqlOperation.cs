using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class SqlOperation
    {
        public string procedureName { get; set; }

        public List<MySqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<MySqlParameter>();
        }


        public void AddVarcharParam(string paramName, string paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }

        public void AddIntNullParam(string paramName, int? paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }
        public void AddDateParam(string paramName, DateOnly paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }

        public void AddDoubleParam(string paramName, Double paramValue)
        {
            Parameters.Add(new MySqlParameter(paramName, paramValue));
        }

    }
}
