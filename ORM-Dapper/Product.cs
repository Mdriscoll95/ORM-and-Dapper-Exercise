using System;
namespace ORM_Dapper
{
	public class Product
	{
		public Product()
		{
		}
		public int ProductID { get; set; }
		public string Name { get; set; }
		public double price { get; set; }
		public int CategoryID { get; set; }
		public int Onsale { get; set; }
		public string StockLevel { get; set; }
	}
}

