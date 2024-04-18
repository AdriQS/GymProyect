using System;
using DataAccess.DAOs;
using Model;

namespace DataAccess.CRUD
{
    public class PlanCRUD : CrudFactory
    {
        public PlanCRUD()
        {
            _dao = SqlDao.GetInstance();
        }

        public override void Create(BaseModel baseModel)
        {
            var plan = baseModel as Plan;

            var sqlOperation = new SqlOperation { procedureName = "CreatePlan" };
            sqlOperation.AddIntParam("P_cost", plan.cost);
            sqlOperation.AddIntParam("P_months", plan.months);
            sqlOperation.AddIntNullParam("P_idUser", plan.idUser);


            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(int id)
        {
            var sqlOperation = new SqlOperation { procedureName = "DeletePlan" };
            sqlOperation.AddIntParam("P_id", id);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstPlan = new List<T>();

            var sqlOperation = new SqlOperation { procedureName = "RetriveAllPlans" };


            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var plan = BuildPlan<T>(row);
                    lstPlan.Add(plan);
                }
            }

            return lstPlan;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { procedureName = "RetrivePlanById" };
            sqlOperation.AddIntParam("P_id", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                var plan = BuildPlan<T>(row);
                return plan;
            }

            return default(T);
        }

        public override void Update(BaseModel baseModel, int id)
        {
            var plan = baseModel as Plan;

            var sqlOperation = new SqlOperation { procedureName = "UpdatePlan" };
            sqlOperation.AddIntParam("P_id", id);
            sqlOperation.AddIntParam("P_cost", plan.cost);
            sqlOperation.AddIntParam("P_months", plan.months);
            sqlOperation.AddIntNullParam("P_idUser", plan.idUser);


            _dao.ExecuteProcedure(sqlOperation);
        }

        private T BuildPlan<T>(Dictionary<string, object> row)
        {
            var plan = new Plan()
            {
                id = (int)row["id"],
                cost = (int)row["cost"],
                months = (int)row["months"],
                idUser = row["idUser"] != DBNull.Value ? (int)row["idUser"] : (int?)null,
            };
            return (T)Convert.ChangeType(plan, typeof(T));
        }
    }
}

