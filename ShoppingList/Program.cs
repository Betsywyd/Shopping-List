using System.Linq;

namespace ShoppingList
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Chirpus Market!");
            Console.WriteLine("{0,-20}{1,-40}", "item", "price");
            Console.WriteLine("=================================");
            Dictionary<string, decimal> manuToPrice = new Dictionary<string, decimal>();
            manuToPrice.Add("apple", (decimal)0.99);
            manuToPrice.Add("banana", (decimal)0.59);
            manuToPrice.Add("cauliflower", (decimal)1.59);
            manuToPrice.Add("dragonfruit", (decimal)2.19);
            manuToPrice.Add("Elderberry", (decimal)1.79);
            manuToPrice.Add("figs", (decimal)2.09);
            manuToPrice.Add("grapefruit", (decimal)1.99);
            manuToPrice.Add("honeydew", (decimal)3.49);

            List<string> orderToCart = new List<string>();

            foreach (var s in manuToPrice)
            {
                Console.WriteLine("{0,-20} {1,-40}", s.Key, s.Value);
            }

            Console.WriteLine();

            bool goOn = true;
            do {
                string s = AddItem(manuToPrice, orderToCart);

                if (s != "Sorry, we don't have those.  Please try again.")
                {
                    Console.WriteLine($"Adding {s}  to cart at:  {manuToPrice[s]}");

                }
                else
                {
                    Console.WriteLine(s);
                }
                
                    goOn = Continue();
                

                } while (goOn == true) ;

            if(goOn == false)
            {
                Console.WriteLine("Thanks for your order! Here's what you got: ");
                Console.WriteLine();
                decimal sum = 0;
                Console.WriteLine("{0,-20}{1,-40}", "item", "price");
                Console.WriteLine("=================================");
                List<decimal> orderPrice= new List<decimal>();
                for (int i = 0;i< orderToCart.Count;i++)
                {
                    Console.WriteLine("{0,-20} {1,-40}", orderToCart[i], manuToPrice[orderToCart[i]]);
                    orderPrice.Add(manuToPrice[orderToCart[i]]);
                    sum += manuToPrice[orderToCart[i]];
                }
                Console.WriteLine();
                Console.WriteLine("{0,-20} {1,-40}", "Total", sum);
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Total price in your cart is: {sum}. ");
                decimal average=sum/orderToCart.Count;
                Console.WriteLine($"Average price per item in order was: {average}. ");
                decimal maxOrder= orderPrice.ToArray().Max();
                decimal minOrder = orderPrice.ToArray().Min();
                int indexMax=0;
                int indexMin = 0;
                for (int i = 0; i < orderPrice.Count; i++)
                {
                    if (orderPrice[i] == maxOrder)
                    {
                        indexMax = i;
                    }
                    else if(orderPrice[i] == minOrder)
                    {
                        indexMin = i;
                    }
                }
                Console.WriteLine($"The most expensive item is {orderToCart[indexMax]},price is {orderPrice[indexMax]}");
                Console.WriteLine($"The least expensive item is {orderToCart[indexMin]},price is {orderPrice[indexMin]}");


            }

            }
            


        public static string AddItem(Dictionary<string,decimal> dic1 , List<string> list)
        {

            Console.Write("What item would you like to order ?\t");

            string item = Console.ReadLine().ToLower().Trim();

            for (int i = 0; i < dic1.Count; i++)
            {
                List<string> keys = dic1.Keys.ToList();
             
                if (item == keys[i].ToLower().Trim())
                {
                    list.Add(keys[i]);
                    return keys[i];
                }
            }
            return "Sorry, we don't have those.  Please try again.";


        }


        public static bool Continue()
        {
            Console.WriteLine("Would you like to order anything else (yes/no)?");
            string a = Console.ReadLine().ToLower();

            if (a == "yes")
            {
                return true;
            }
            else if (a == "no")
            {
               
                return false;
            }
            else
            {
                Console.WriteLine("Enter wrong.");
                return Continue();
            }
        }







    }
}