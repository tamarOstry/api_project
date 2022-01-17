using System;

namespace veichle
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DataAccsess dataAccsess = new DataAccsess();
            Console.WriteLine("hello manager:");
            Console.WriteLine("are you want to application another product? ");
            string status=Console.ReadLine();
            while (status=="y")
            {
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                Console.WriteLine("enter price");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("enter description");
                string desc = Console.ReadLine();
                Console.WriteLine("enter category_id");
                int category_id = int.Parse(Console.ReadLine());
                Console.WriteLine("enter image");
                string image = Console.ReadLine();
                dataAccsess.addProduct(name, price, desc, category_id, image);
                Console.WriteLine("are you want to application another product? ");
                status = Console.ReadLine();
            };
            Console.WriteLine("witch product you want his details");
            string prod = Console.ReadLine();
            dataAccsess.selectProduct(prod);
        }
    }
}
