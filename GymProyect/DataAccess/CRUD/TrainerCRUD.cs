using System;
using DataAccess.DAOs;
using Model;

namespace DataAccess.CRUD
{
    public class TrainerCRUD : CrudFactory
    {

        public TrainerCRUD()
        {
            _dao = SqlDao.GetInstance();
        }

        public override void Create(BaseModel baseModel)
        {
            var trainer = baseModel as Trainer;

            var sqlOperation = new SqlOperation { procedureName = "CreateTrainer" };

            sqlOperation.AddVarcharParam("P_name", trainer.name);
            sqlOperation.AddVarcharParam("P_lastNames", trainer.lastNames);
            sqlOperation.AddVarcharParam("P_email", trainer.email);
            sqlOperation.AddVarcharParam("P_password", trainer.password);
            sqlOperation.AddIntParam("P_phone", trainer.phone);
            sqlOperation.AddIntParam("P_experienceYears", trainer.experienceYears);
            sqlOperation.AddIntNullParam("P_idUser", trainer.idUser);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(int id)
        {
            var sqlOperation = new SqlOperation { procedureName = "DeleteTrainer" };
            sqlOperation.AddIntParam("P_id", id);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstTrainer = new List<T>();

            var sqlOperation = new SqlOperation { procedureName = "RetriveAllTrainers" };


            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var trainer = BuildTrainer<T>(row);
                    lstTrainer.Add(trainer);
                }
            }

            return lstTrainer;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { procedureName = "RetriveTrainerById" };
            sqlOperation.AddIntParam("P_id", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                var trainer = BuildTrainer<T>(row);
                return trainer;
            }

            return default(T);
        }

        public override void Update(BaseModel baseModel, int id)
        {
            var trainer = baseModel as Trainer;

            var sqlOperation = new SqlOperation { procedureName = "UpdateTrainer" };

            sqlOperation.AddIntParam("P_id", id);
            sqlOperation.AddVarcharParam("P_name", trainer.name);
            sqlOperation.AddVarcharParam("P_lastNames", trainer.lastNames);
            sqlOperation.AddVarcharParam("P_email", trainer.email);
            sqlOperation.AddVarcharParam("P_password", trainer.password);
            sqlOperation.AddIntParam("P_phone", trainer.phone);
            sqlOperation.AddIntParam("P_experienceYears", trainer.experienceYears);
            sqlOperation.AddIntNullParam("P_idUser", trainer.idUser);
            _dao.ExecuteProcedure(sqlOperation);
        }
        private T BuildTrainer<T>(Dictionary<string, object> row)
        {
            var trainer = new Trainer()
            {
                id = (int)row["id"],
                name = (string)row["name"],
                lastNames = (string)row["lastNames"],
                email = (string)row["email"],
                password = (string)row["password"],
                phone = (int)row["phone"],
                experienceYears = (int)row["experienceYears"],
                idUser = row["idUser"] != DBNull.Value ? (int)row["idUser"] : (int?)null
            };
            return (T)Convert.ChangeType(trainer, typeof(T));
        }
    }
}

