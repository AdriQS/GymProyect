using System;
namespace Model
{
	public class Trainer : BaseModel
	{
		public string name { get; set; }
		public string lastNames { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public int phone { get; set; }
		public int experienceYears { get; set; }
		public int? idUser { get; set; }

    }
}

