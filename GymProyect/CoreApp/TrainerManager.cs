using System;
using System.Text.RegularExpressions;
using DataAccess.CRUD;
using Model;
namespace CoreApp
{
	public class TrainerManager
	{
		public void Create(Trainer trainer)
		{
            if (string.IsNullOrEmpty(trainer.name))
            {
                throw new Exception("Name is required");
            }
            if (string.IsNullOrEmpty(trainer.lastNames))
            {
                throw new Exception("Last names are required");
            }
            if (string.IsNullOrEmpty(trainer.email))
            {
                throw new Exception("Email is required");
            }
            if (!ValidPhone(trainer.phone))
            {
                throw new Exception("Phone is invalid");
            }
            if (trainer.experienceYears < 1)
            {
                throw new Exception("Trainer need at least 1 experience year");
            }
            if (!ValidPassword(trainer.password))
            {
                throw new Exception("The password is invalid, password must have at least one uppercase, one lowercase and one numeric digit");
            }
            var tc = new TrainerCRUD();
            tc.Create(trainer);
        }

		public void Delete(int id)
		{
            var tc = new TrainerCRUD();
            tc.Delete(id);
		}

        public List<Trainer> RetriveAll()
		{
            var tc = new TrainerCRUD();

            var lstTrainer = tc.RetrieveAll<Trainer>();

            foreach (var trainer in lstTrainer)
            {
                trainer.password = null;
            }

            return lstTrainer;
        }

		public Trainer? RetriveById(Trainer trainer)
		{
            var tc = new TrainerCRUD();
            var retrievedTrainer = tc.RetrieveById<Trainer>(trainer.id);

            retrievedTrainer.password = null;

            return retrievedTrainer;
        }

        public void Update(Trainer trainer, int id)
		{
            if (string.IsNullOrEmpty(trainer.name))
            {
                throw new Exception("Name is required");
            }
            if (string.IsNullOrEmpty(trainer.lastNames))
            {
                throw new Exception("Last names are required");
            }
            if (string.IsNullOrEmpty(trainer.email))
            {
                throw new Exception("Email is required");
            }
            if (!ValidPhone(trainer.phone))
            {
                throw new Exception("Phone is invalid");
            }
            if (trainer.experienceYears < 1)
            {
                throw new Exception("Trainer need at least 1 experience year");
            }
            if (!ValidPassword(trainer.password))
            {
                throw new Exception("The password is invalid, password must have at least one uppercase, one lowercase and one numeric digit");
            }
            var tc = new TrainerCRUD();
            tc.Update(trainer, id);
        }

        public bool ValidPhone(int phone)
        {
            string phoneStr = phone.ToString();

            return phoneStr.Length == 8;
        }

        public bool ValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

            return regex.IsMatch(password);
        }
    }
}

