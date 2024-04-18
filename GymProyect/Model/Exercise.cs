using System;
namespace Model
{
	public class Exercise : BaseModel
	{
		public string name { get; set; }
		public string muscle { get; set; }
		public int userId { get; set; }
    }
}

