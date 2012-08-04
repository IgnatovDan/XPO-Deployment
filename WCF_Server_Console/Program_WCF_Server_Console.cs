using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using System.ServiceModel;
using DevExpress.Xpo.Metadata;
using PersistentClassesLibrary;

namespace WCF_Server_Console {
    class Program {
        static void Main(string[] args) {
            XPDictionary dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(typeof(Person).Assembly);

            Console.WriteLine("Opening service host...");

            ThreadSafeDataLayer dataLayer = new ThreadSafeDataLayer(dictionary, XpoDefault.GetConnectionProvider(Constants.DatabaseConnectionString, AutoCreateOption.SchemaAlreadyExists));
            SerializableObjectLayer objectlayer = new SerializableObjectLayer(new UnitOfWork(new SimpleObjectLayer(dataLayer)));
            ServiceHost host = new ServiceHost(new SerializableObjectLayerSingletonService(objectlayer));
            host.AddServiceEndpoint(typeof(ISerializableObjectLayerService), new BasicHttpBinding(), Constants.WCF_Server_Uri);
            host.Open();

            Console.WriteLine("Service host is opened.");
            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
            
            Console.WriteLine("Closing service host...");
            host.Close();
            Console.WriteLine("Service host is closed.");
        }
    }
}
