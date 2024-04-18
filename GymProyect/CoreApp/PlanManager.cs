using System;
using Model;
using DataAccess.CRUD;
namespace CoreApp
{
	public class PlanManager
	{
		public void Create(Plan plan)
		{
			if (plan.cost < 0)
			{
				throw new Exception("The cost can't be under 0");
			}
			if (plan.months < 1)
			{
                throw new Exception("The cant of months are invalid");
            }

			var pc = new PlanCRUD();
			pc.Create(plan);
		}

		public void Delete(int id)
		{
			var pc = new PlanCRUD();
			pc.Delete(id); 
		}

        public List<Plan> RetriveAll()
		{
            var pc = new PlanCRUD();

            var lstPlans = pc.RetrieveAll<Plan>();

            return lstPlans;
        }

        public Plan? RetriveById(Plan plan)
		{
            var pc = new PlanCRUD();

            return pc.RetrieveById<Plan>(plan.id);
        }

        public void Update(Plan plan, int id)
		{
            if (plan.cost < 0)
            {
                throw new Exception("The cost can't be under 0");
            }
            if (plan.months < 1)
            {
                throw new Exception("The cant of months are invalid");
            }

            var pc = new PlanCRUD();
            pc.Update(plan, id);
        }

    }
}

