using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2S_Joins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER key to execute retrieval without options");
            Console.ReadLine();

            using (var dc = new DataStoreDataContext())
            {
                var customers = from c in dc.Customers
                                select c;

                customers.ToList().ForEach(c =>
                {
                    Console.WriteLine("Name: {0} has {1} orders.", c.CustomerName,c.Orders.Count);
                });
            }

            Console.WriteLine("Done. Press ENTER.");
            Console.ReadLine();
        }

    }
}
