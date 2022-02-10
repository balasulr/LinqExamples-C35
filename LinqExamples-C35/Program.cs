using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples_C35 {
    // Learning LINQ code & notes
    class Program {
        static void Main(string[] args) {
            ///////////////////////////////////////////////////////////////////////////////////////
            Console.Write($"----------------------------------------------------------------------------------\n");
            int[] ints = new int[] {
                869,   842,    861,    672,    757,    144,    397,    110,    109,    111,
                104,    348,    551,    624,    141,    887,    792,    395,    281,    737,
                612,    740,    574,    313,    672,    404,    523,    507,    843,    164,
                233,    115,    338,    905,    378,    761,    169,    666,    354,    453,
                501,    469,    406,    948,    417,    149,    909,    334,    321,    645,
                370,    933,    483,    770,    681,    631,    108,    151,    726,    876,
                869,    464,    827,    678,    240,    971,    903,    709,    380,    246,
                733,    915,    503,    474,    445,    866,    152,    447,    560,    387,
                726,    314,    477,    523,    483,    452,    250,    966,    677,    442,
                841,    278,    406,    787,    710,    769,    570,    145,    555,    774
            };

            Console.Write($"The Count is: {ints.Count()}.\n");
            Console.Write($"The Total of the 100 numbers is: {ints.Sum()}.\n\n");
            Console.Write($"The Average of the 100 numbers is: {ints.Average()}.\n\n");

            Console.Write($"The Minimum of the 100 numbers is: {ints.Min()}.\n");
            Console.Write($"The Maximum of the 100 numbers is: {ints.Max()}.\n");

            Console.Write("\n");
            Console.Write($"----------------------------------------------------------------------------------\n");
            Console.WriteLine("\n");

            ///////////////////////////////////////////////////////////////////////////////////////
            // Collections of Customers
            List<Customer> customers = new List<Customer>() {
                new Customer() { Id = 1, Name = "MAX", Sales = 1000},
                new Customer() { Id = 2, Name = "PG", Sales = 1000000},
                new Customer() { Id = 3, Name = "Microsoft", Sales = 500000},
                new Customer() { Id = 4, Name = "Amazon", Sales = 10000000},
                new Customer() { Id = 5, Name = "Google", Sales = 5000400},
            };
            
            // Adding Orders
            List<Order> orders = new List<Order>() {
                new Order() {Id = 1, Description = "1st Order",
                    Total = 1000, CustomerId = 2},
                new Order() {Id = 2, Description = "2nd Order",
                    Total = 2000, CustomerId = 5},
                new Order() {Id = 3, Description = "3rd Order",
                    Total = 3000, CustomerId = 1}
            };

            // Inner Join
            var customerOrders = from o in orders
                                 join c in customers
                                 on o.CustomerId equals c.Id // First column must be from one of previous tables then equals and other table
                                 orderby o.Total descending
                                 select new {
                                     o.Id, o.Description,
                                     Amount = o.Total, // Alias o.Total as Amount
                                     Customer = c.Name
                                 };
            foreach(var co in customerOrders) {
                Console.WriteLine($"{co.Id, -5} {co.Description,-30}" +
                                    $"{co.Amount,7:c}{co.Customer,25}");
            }

            Console.Write($"----------------------------------------------------------------------------------\n");

            // Sorting Sales descending showing Name & Sales
            var orderCustomers = from c in customers
                                 orderby c.Sales descending
                                 select new {
                                     c.Name, c.Sales
                                 };

            foreach(var c in orderCustomers) {
                Console.WriteLine($"{c.Name, -15} {c.Sales,15:c}");
            }

            Console.Write($"-----------------------------------\n");
            // Collection of numbers
            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,-63, 7, 88, 53, -1, 12, 17 };

            // Sum of all numbers in list
            Console.WriteLine($"The total is: {numbers.Sum()}.");
            Console.Write($"-----------------------------------\n");

            ///////////////////////////////////////////////////////////////////////////////////////
            /// LINQ Query Syntax (similiar to SQL syntax but uses collections)
            var qnbrs = from n in numbers // n is a alias representing the collection of numbers
                        where n < 200 // Optional
                        orderby n // Opional if need to order
                        select n; // Mandatory to include

            ///////////////////////////////////////////////////////////////////////////////////////
            //// Linq Method Syntax
            // Numbers Greater than or equal to 50 and less than or equal to 100
            int[] numGTE50LTE100 = numbers.Where(nbr => nbr >= 50 && nbr <= 100).ToArray();

            ///////////////////////////////////////////////////////////////////////////////////////
            // All numbers which are less than 200
            int[] numLT200 = numbers.Where(t => t < 200).ToArray();
            ///////////////////////////////////////////////////////////////////////////////////////
            // Sorting odd numbers in decending order
            int[] numbers2 = numbers
                .Where(n => n % 2 == 1)
                .OrderByDescending(x => x)
                .ToArray();
            foreach(int n1 in numbers2) {
                Console.Write($"{n1} ");
            }
            
            Console.WriteLine($"\n"); // Line Break to separate
            Console.Write($"-----------------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////
            // Looking for odd numbers and adding them up
            int total = 0;
            foreach(int n in numbers) {
                if(n % 2 == 1) {
                    total += n;
                    Console.Write($"{n} "); // Writes all the odd numbers on one line
                }
            }
            Console.WriteLine("\n\nThe total of the odd numbers is: \n");
            Console.WriteLine(total);

            Console.Write($"-----------------------------------\n");
            ///////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
