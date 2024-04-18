using System;
namespace Model
{
	public class Plan : BaseModel
	{
		public string name { get; set; }
		public int cost { get; set; }
		public int months { get; set; }
    }
}

