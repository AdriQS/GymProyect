using System;
using DataAccess.DAOs;
using Model;

namespace DataAccess.CRUD
{
    public class UserCRUD : CrudFactory
    {
        public UserCRUD()
        {
            _dao = SqlDao.GetInstance();
        }

        public override void Create(BaseModel baseModel)
        {
            var user = baseModel as User;

            var sqlOperation = new SqlOperation { procedureName = "CreateUser" };
            sqlOperation.AddVarcharParam("P_name", user.name);
            sqlOperation.AddVarcharParam("P_lastNames", user.lastNames);
            sqlOperation.AddVarcharParam("P_email", user.email);
            sqlOperation.AddVarcharParam("P_password", user.password);
            sqlOperation.AddIntParam("P_phone", user.phone);
            sqlOperation.AddVarcharParam("P_rol", user.rol);
            sqlOperation.AddIntNullParam("P_idTrainer", user.idTrainer);
            sqlOperation.AddIntNullParam("P_idPlan", user.idPlan);
            sqlOperation.AddIntNullParam("P_idExercise", user.idExercise);


            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(int id)
        {
            var sqlOperation = new SqlOperation { procedureName = "DeleteUser" };
            sqlOperation.AddIntParam("P_id", id);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUser = new List<T>();

            var sqlOperation = new SqlOperation { procedureName = "RetriveAllUsers" };


            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var client = BuildUser<T>(row);
                    lstUser.Add(client);
                }
            }

            return lstUser;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { procedureName = "RetriveUserById" };
            sqlOperation.AddIntParam("P_id", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                var client = BuildUser<T>(row);
                return client;
            }

            return default(T);
        }

        public override void Update(BaseModel baseModel, int id)
        {
            var user = baseModel as User;

            var sqlOperation = new SqlOperation { procedureName = "UpdateUser" };

            sqlOperation.AddIntParam("P_id", id);
            sqlOperation.AddVarcharParam("P_name", user.name);
            sqlOperation.AddVarcharParam("P_lastNames", user.lastNames);
            sqlOperation.AddVarcharParam("P_email", user.email);
            sqlOperation.AddVarcharParam("P_password", user.password);
            sqlOperation.AddIntParam("P_phone", user.phone);
            sqlOperation.AddVarcharParam("P_rol", user.rol);
            sqlOperation.AddIntNullParam("P_idTrainer", user.idTrainer);
            sqlOperation.AddIntNullParam("P_idPlan", user.idPlan);
            sqlOperation.AddIntNullParam("P_idExercise", user.idExercise);
            _dao.ExecuteProcedure(sqlOperation);
        }

        private T BuildUser<T>(Dictionary<string, object> row)
        {
            var client = new User()
            {
                id = (int)row["id"],
                name = (string)row["name"],
                lastNames = (string)row["lastNames"],
                email = (string)row["email"],
                password = (string)row["password"],
                phone = (int)row["phone"],
                rol = (string)row["rol"],
                idTrainer = row["idTrainer"] != DBNull.Value ? (int)row["idTrainer"] : (int?)null,
                idPlan = row["idPlan"] != DBNull.Value ? (int)row["idPlan"] : (int?)null,
                idExercise = row["idExercise"] != DBNull.Value ? (int)row["idExercise"] : (int?)null
            };
            return (T)Convert.ChangeType(client, typeof(T));
        }
    }
}

