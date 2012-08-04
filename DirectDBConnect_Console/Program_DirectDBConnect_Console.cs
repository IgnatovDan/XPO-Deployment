using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using PersistentClassesLibrary;

namespace DirectDBConnect_Console {
    class Program_DirectDBConnect_Console {
        static void Main(string[] args) {
            Console.WriteLine("Starting...");
            using(UnitOfWork uow = new UnitOfWork()) {
                Console.WriteLine("Connecting...");
                uow.ConnectionString = Constants.DatabaseConnectionString;
                uow.Connect();
                foreach(Person p in new XPCollection<Person>(uow)) {
                    Console.WriteLine("Person - FirstName: {0}, LastName: {1}", p.FirstName, p.LastName);
                    foreach(Product product in p.Products) {
                        Console.WriteLine("  Product - Name: {0}, Manager: {1}", product.Name, product.Manager.FirstName + " " + product.Manager.LastName);
                    }
                }
            }
            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }
    }
}
