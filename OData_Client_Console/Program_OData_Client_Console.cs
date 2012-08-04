using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;
using OData_Client_Console.MyXpoDataServiceReference;

namespace OData_Client_Console {
    class Program_OData_Client_Console {
        static void Main(string[] args) {
            Console.WriteLine("Starting...");
            MyXpoDataService ctx = new MyXpoDataServiceReference.MyXpoDataService(new Uri(PersistentClassesLibrary.Constants.OData_Server_Uri));

            var personsQuery1 = (from p in ctx.CreateQuery<Person>("Person")
                                 select p).Take<Person>(1);

            foreach(Person p in personsQuery1) {
                Console.WriteLine("Person - FirstName: {0}, LastName: {1}", p.FirstName, p.LastName);
                foreach(Product product in p.Products) {
                    Console.WriteLine("  Product - Name: {0}, Manager: {1}", product.Name, product.Manager.FirstName + " " + product.Manager.LastName);
                }
            }
            Console.WriteLine("Press Enter to close...");
            Console.ReadLine(); 
            
            
            DataServiceQuery<Person> personsQuery = ctx.CreateQuery<Person>("Person");
            //personsQuery.AddQueryOption("$expand", "Products");
            personsQuery = personsQuery.AddQueryOption("$top", 1);
            personsQuery = personsQuery.AddQueryOption("$inlinecount", "allpages");
            personsQuery = personsQuery.AddQueryOption("$expand", "Products");
            //expand=Products

            //DataServiceQuery<Person> personsQuery = ctx.Person;
            QueryOperationResponse<Person> response = (QueryOperationResponse<Person>)personsQuery.Execute();
            Console.WriteLine("Total count : {0}", response.TotalCount);
            foreach(Person p in personsQuery.Execute()) {
                Console.WriteLine("Person - FirstName: {0}, LastName: {1}", p.FirstName, p.LastName);
                foreach(Product product in p.Products) {
                    Console.WriteLine("  Product - Name: {0}, Manager: {1}", product.Name, product.Manager.FirstName + " " + product.Manager.LastName);
                }
            }
            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }
    }
}
