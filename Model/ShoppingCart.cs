using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShopDatabase
{
	public class ShoppingCart 
    {

		public Guid Id { get; set; }

		public double Sum { get; set; }

		public DateTime DateCreated { get; set; }

        public virtual ICollection<Food> Items { get; set; }//virtuali saab ülekatta alamklassis

		//public Person Client { get; set; }

		//public List<Food> Items { get; set; }

        
		public ShoppingCart()
		{
			Id = Guid.NewGuid();
			DateCreated = DateTime.Now;
			Items = new List<Food>();
            Sum = 0;

		}

		public void AddToCart(Food food)
		{
            Items.Add(food);
            Sum += food.Price;
		}
    
      
        //public double CalculateSum()
        //{
        //	for (int i = 0; i < Items.Count; i++)
        //	{
        //		Sum = Sum + Items[i].Price * Amounts[i];
        //	}
        //	return Sum;
        //}
    }
}
