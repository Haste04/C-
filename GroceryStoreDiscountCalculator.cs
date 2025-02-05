using System;
using System.Collections;

public class UserList
{
    private List<Product> purchasedProducts = new List<Product>();
    public void AddProduct(Product p)
    {
        purchasedProducts.Add(p);
    }

    public void RemoveLastProduct()
    {
       if(purchasedProducts.Count > 0)
       {
            purchasedProducts.RemoveAt(purchasedProducts.Count - 1);
       }
    }

    public List<Product> GetPurchasedProducts()
    {
        return purchasedProducts;
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        for (int i = 0; i < purchasedProducts.Count; i++)
        {
            total += purchasedProducts[i].Price * purchasedProducts[i].Quantity;
        }
        return total;
    }
}

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }
    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

public class Program
{
    public static void Main()
    {
        UserList userList = new UserList();
        bool flag = true;
        int quantity;
        decimal price;

        while(flag)
        {
            Console.WriteLine("Welcome to our Grocery Store\nWhat would you like to purchase?:");
            Console.WriteLine("Banana");
            Console.WriteLine("Apple");
            Console.WriteLine("Soap");
            Console.WriteLine("Shampoo");
            Console.WriteLine("Chicken");
            Console.WriteLine("Pork");
            Console.WriteLine("Fish");
            string userChoice = Console.ReadLine();

            switch(userChoice.ToLower()) 
            {
                 case "banana":
                    quantity = GetQuantity("bananas");
                    price = GetPrice("bananas");
                    userList.AddProduct(new Product("Banana", price, quantity));
                    break;

                case "apple":
                    quantity = GetQuantity("apples");
                    price = GetPrice("apple");
                    userList.AddProduct(new Product("Apple", price, quantity));
                    break;

                case "soap":
                    quantity = GetQuantity("soaps");
                    price = GetPrice("soap");
                    userList.AddProduct(new Product("Soap", price, quantity));
                    break;

                case "shampoo":
                    quantity = GetQuantity("shampoos");
                    price = GetPrice("shampoo");
                    userList.AddProduct(new Product("Shampoo", price, quantity));
                    break;

                case "chicken":
                    quantity = GetQuantity("chicken meats");
                    price = GetPrice("chicken meat");
                    userList.AddProduct(new Product("Chicken", price, quantity));
                    break;

                case "pork":
                    quantity = GetQuantity("pork meats");
                    price = GetPrice("pork meat");
                    userList.AddProduct(new Product("Pork", price, quantity));
                    break;

                case "fish":
                    quantity = GetQuantity("fish meats");
                    price = GetPrice("fish meat");
                    userList.AddProduct(new Product("Fish", price, quantity));
                    break;

                default:
                    Console.WriteLine("Please enter the name of the item correctly!");
                    continue;
            }

            if(userList.GetPurchasedProducts().Count > 0)
            {
                Console.WriteLine("Would you like to remove the previous item? [Yes] or [No]");
                string remove = Console.ReadLine().ToLower().Trim();
                if (remove == "yes" || remove == "y")
                userList.RemoveLastProduct(); 
            }
            else
            {
                Console.WriteLine("There are no items in the list");
            }
            Console.WriteLine("Would you like to purchase more items? [Yes] or [No]");
            int count = 1;
            foreach(var product in userList.GetPurchasedProducts())
            {
                Console.WriteLine($"Item {count++}: {product.Name} - {product.Quantity} pcs");
            }

            string buyMore = Console.ReadLine().ToLower().Trim();
            if (buyMore == "no" || buyMore == "n")
            {
                flag = false;
            }
        }
        decimal subtotal = userList.CalculateTotal();
        decimal discount = subtotal > 500 ? 0.20m : 
                           subtotal > 200 ? 0.15m : 
                           subtotal > 100 ? 0.10m : 0;
        decimal total = subtotal - (subtotal * discount);
        Console.WriteLine($"Total price of purchased products: ${total:C}");
    }

    private static int GetQuantity(string item)
    {
        Console.WriteLine($"How many {item} would you like to purchase?");
        return Convert.ToInt32(Console.ReadLine());
    }

    private static decimal GetPrice(string item)
    {
        Console.WriteLine($"What is the price of the {item}?");
        return Convert.ToDecimal(Console.ReadLine());
    }
}
