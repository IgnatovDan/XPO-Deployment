using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using PersistentClassesLibrary;

namespace _CreateDatabase {
    class Program_CreateDatabase {
        static void Main(string[] args) {
            Console.WriteLine("Creating database/deleting records...");
            using(UnitOfWork uow = new UnitOfWork()) {
                uow.ConnectionString = Constants.DatabaseConnectionString;
                uow.UpdateSchema(typeof(Person));
                foreach(Person p in new System.Collections.ArrayList(new XPCollection<Person>(uow))) {
                    uow.Delete(p);
                }
                foreach(Product p in new System.Collections.ArrayList(new XPCollection<Product>(uow))) {
                    uow.Delete(p);
                }
                uow.CommitChanges();
            }

            Console.WriteLine("Creating records...");
            using(UnitOfWork uow = new UnitOfWork()) {
                uow.ConnectionString = Constants.DatabaseConnectionString;
                uow.UpdateSchema(typeof(Person));
                Person p1 = new Person(uow);
                p1.FirstName = "Slava";
                p1.LastName = "Donchak";

                Person p2 = new Person(uow);
                p2.FirstName = "Dan";
                p2.LastName = "Ignatov";

                Product xaf = new Product(uow);
                xaf.Name = "Xaf";
                xaf.Manager = p2;

                Product xpo = new Product(uow);
                xpo.Name = "Xpo";
                xpo.Manager = p1;

                uow.CommitChanges();
            }
            Console.WriteLine("Database is recreated.");
            Console.ReadLine();
        }
    }
}
