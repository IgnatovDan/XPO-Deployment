using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.ServiceModel;
using PersistentClassesLibrary;
using DevExpress.Xpo.Metadata;

namespace WCF_Client_Console {
    class Program_WCF_Client_Console {
        static void Main(string[] args) {
            Console.WriteLine("Starting...");
            SerializableObjectLayerServiceClient clientObjectLayer = new SerializableObjectLayerServiceClient(new BasicHttpBinding(), new EndpointAddress(Constants.WCF_Server_Uri));

            XPDictionary dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(typeof(Person).Assembly);
            using(UnitOfWork uow = new UnitOfWork(new SerializableObjectLayerClient(clientObjectLayer, dictionary))) {
                Console.WriteLine("Connecting...");
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
