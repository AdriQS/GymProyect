using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataAccess.DAOs
{
    public class SqlDao
    {

        private string _connectionString;


        private static SqlDao? _instance;


        private SqlDao()
        {
            _connectionString = "Server=45.88.196.5;Database=u484426513_grupo6diseno;Uid=u484426513_grupo6diseno;Pwd=Grupo1diseno!;";
        }


        public static SqlDao GetInstance()
        {

            if (_instance == null)
            {
                _instance = new SqlDao();
            }

            return _instance;

        }



        public void ExecuteProcedure(SqlOperation sqlOperation)
        {

            using (var conn = new MySqlConnection(_connectionString))
            {

                using (var command = new MySqlCommand(sqlOperation.procedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {

                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);

                    }

                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }


        }


        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResults = new List<Dictionary<string, object>>();

            using (var conn = new MySqlConnection(_connectionString))
            {

                using var command = new MySqlCommand(sqlOperation.procedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);

                }


                conn.Open();

                var reader = command.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        var row = new Dictionary<string, object>();

                        for (var index = 0; index < reader.FieldCount; index++)
                        {
                            var key = reader.GetName(index);
                            var value = reader.GetValue(index);

                            row[key] = value;
                        }
                        lstResults.Add(row);
                    }
                }

            }

            return lstResults;
        }
    }
}