using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> groceries = new List<Food>
            {
                new Food("sandwich", 0.5),
                new Food("grapes", 1.7),
                new Food("milk", 2.5),
                new Food("apple", 3),
                new Food("cheese", 2)
            };

            ShoppingCart newCart = new ShoppingCart();

            //ChooseFood(groceries, newCart);
            /*foreach (var food in groceries)
			{
				newCart.Items.Add(food);
			}*/

            ChooseFood(groceries, newCart);

            while (Console.ReadLine() == "Yes")
            {
                ChooseFood(groceries, newCart);
            }

            using (var db = new ShopDbContext())


            {
                var cartWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
                foreach (var cart in cartWithZeroSum)
                {
                    db.ShoppingCarts.Remove(cart);
                }

                db.SaveChanges();
                db.ShoppingCarts.Add(newCart);
                db.SaveChanges();

                var carts = db.ShoppingCarts.Include("Items").OrderByDescending(c => c.DateCreated).ToList();



                foreach (var cart in carts)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                    Console.WriteLine("Items in cart:");

                    foreach (var food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");

                    }
                    Console.WriteLine($"Total: {cart.Sum}");
                    Console.WriteLine("****");
                }

                //show only the last(latest created) shopping cart with all its items
                /*   var carts1 = db.ShoppingCarts.OrderByDescending(c => c.DateCreated).First();

                   Console.WriteLine($"Last shopping cart created on {carts1.DateCreated}");
                   Console.WriteLine("*****");
                   Console.WriteLine("Items in cart:");

                   foreach (var cart in carts1.Items)
                   {

                       Console.WriteLine($"{cart.Name}");

                   }
                   Console.ReadLine();*/


                //show only carts with sum > 5
                /*  var carts2 = db.ShoppingCarts.Include("Items").Where(cart => cart.Sum > 5);
                      foreach (var cart in carts2)
                  {
                      Console.WriteLine("");
                      Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                      Console.WriteLine("Total sum of shopping cart over 5 euros");

                      foreach(var food in cart.Items)
                      {
                          Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");

                      }
                      Console.WriteLine($"Total sum is: {cart.Sum}");
                      Console.WriteLine("****");
                       }*/

                //show only the carts with  more than one item in it(and how many items in it)
                /* var carts3 = db.ShoppingCarts.Include("Items").Where(cart => cart.Items.Count > 1);
                 foreach (var cart in carts3)
                 {
                     Console.WriteLine("");
                     Console.WriteLine("");
                     Console.WriteLine($"Shopping cart created on {cart.DateCreated}");

                     foreach (var food in cart.Items)
                     {
                         Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");

                     }
                     Console.WriteLine($"Cart has {cart.Items.Count()} items in it");
                     Console.WriteLine($"Total sum is: {cart.Sum}");
                     Console.WriteLine("****");
                 }
                 Console.ReadLine();*/

                //show only the carts that contain apple TEHHA

               /* var carts4 = db.ShoppingCarts.Where(x => x.Items.Any(y => y.Name == "apple"));

                foreach (var cart in carts4)
                {
                    Console.WriteLine("******");
                    Console.WriteLine(" ");
                    Console.WriteLine("Shopping carts that contain apple");
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}");


                    foreach (var food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");

                    }
                    Console.WriteLine($"Total: {cart.Sum}");
                }
                
                   Console.ReadLine();*/

                //show the total number of shopping carts
                /* var carts5 = db.ShoppingCarts.Count();


                     Console.WriteLine($"Total number on shopping carts: {carts5}");*/

                //show the cart with maxium sum
                /* var cart6 = db.ShoppingCarts.Max(z => z.Sum);
                     {
                     Console.WriteLine($"Cart's maxium sum: {cart6}");
                 }*/
                //show the cheapest food
                /* double cart7 = db.Foods.Min(z => z.Price);
                 {
                     Console.WriteLine($"Cheapest food costs {cart7}" );
                 }*/





            }


        }
        private static void ChooseFood(List<Food> groceries, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy?");
            var foodName = Console.ReadLine();
            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCart(chosenFood);
            Console.WriteLine("Anything else? Yes/No");
        }

    }
}
   