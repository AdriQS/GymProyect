using System;
namespace Model
{
	public class Machine : BaseModel
	{
		public string name { get; set; }
		public string muscle { get; set; }
		public DateTime admissionDate { get; set; }
    }
}

