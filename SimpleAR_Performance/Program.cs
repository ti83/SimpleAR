using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleAR_DAL.DBModels;
using SimpleAR_DAL.Factories;
using SimpleAR_DAL.Managers;

namespace SimpleAR_Performance
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AddCustomers();
            Console.WriteLine("Getting Customer Dictionary.");
            var idTable = GenerateCustomerIdHash();

            for (int x = 0; x < 70; x++)
            {
                AddLedgers(idTable, x);
            }

            Console.ReadKey();
        }

        private static void AddCustomers()
        {
            for (int x = 0; x < 100; x++)
            {
                var name = string.Format("Blargity Test {0}",x);
                CustomerManager.SaveCustomer(new Customer() { Name = name });
                Console.WriteLine(name);
            }
            var count = CustomerManager.GetCustomers().Count;
            Console.WriteLine("Customer count: {0}",count);
        }

        private static void AddLedgers(Dictionary<int,Customer>idTable, int iteration)
        {
            Console.WriteLine("Iteration: {0}", iteration);
            var rnd = new Random();

            Console.Write("     Starting Construction.");
            var sw = new Stopwatch();
            sw.Start();
            var collection = new List<Ledger>();
            for (int x = 0; x < 10000; x++)
            {
                var IdIndex = rnd.Next(0, idTable.Count - 1);

                var customer = idTable[IdIndex];
                var ledger = CreateLedger(customer, 2);
                //LedgerManager.SaveLedgerItem(ledger);
                collection.Add(ledger);
                //Console.WriteLine("{0}: {2} - {1}", x, ledger.DOS, ledger.CustomerName);
            }
            sw.Stop();
            Console.WriteLine("..It took {0}ms", sw.Elapsed.Milliseconds);
            Console.Write("     Starting save.");
            sw = new Stopwatch();
            sw.Start();
            SaveCollection(collection);
            sw.Stop();
            Console.WriteLine("..It took {0}s", sw.Elapsed.TotalSeconds);
        }

        private static void SaveCollection(List<Ledger> collection,int errorCount = 0)
        {
            if (errorCount == 3)
            {
                Console.WriteLine("..It failed.");
            }
            try
            {
                var context = ManagerFactories.CreateContextManager();
                context.LedgerRecords.AddRange(collection);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Thread.SpinWait(1000);
                SaveCollection(collection, errorCount++);
            }
        }


        private static Ledger CreateLedger(Customer customer,int serviceId)
        {
            return new Ledger()
            {
                CustomerId = customer.Id.Value,
                ServiceId = serviceId,
                ServiceName = "Test service",
                CustomerName = customer.Name,
                DOS = RandomDay(),
                PricePerUnit = 40,
                NumberOfUnits = 5,
                UnitType = "hrs"
            };
        }

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(2010, 1, 1);
            Random gen = new Random();

            int range = (DateTime.Today.AddYears(50) - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private static Dictionary<int,Customer> GenerateCustomerIdHash()
        {
            var customers = CustomerManager.GetCustomers();
            var table = new Dictionary<int, Customer>();

            foreach (var customer in customers)
            {
                if (customer.Id.HasValue && !table.ContainsKey(customer.Id.Value))
                {
                    table.Add(table.Count,customer);
                }
            }
            return table;
        }

    }
}
