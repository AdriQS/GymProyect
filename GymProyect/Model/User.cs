using System;
namespace Model
{
	public class User : BaseModel 
	{
		public string name { get; set; }
		public string lastNames { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public int phone { get; set; }
		public string rol { get; set; }
		public int? idTrainer { get; set; }
        public int? idPlan { get; set; }
        public int? idExercise { get; set; }
    }
}

