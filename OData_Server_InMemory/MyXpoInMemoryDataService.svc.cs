using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using PersistentClassesLibrary;

namespace OData_Server_InMemory {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyXpoInMemoryDataService : XpoDataService {
        public MyXpoInMemoryDataService() : base(new XpoContext("MyXpoDataService", "PersistentClassesLibrary", CreateDataLayer())) { }
        static IDataLayer CreateDataLayer() {
            DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(Person).Assembly);
            DataSetDataStore dataStore = new DataSetDataStore(new DataSet(), AutoCreateOption.DatabaseAndSchema);
            using(UnitOfWork uow = new UnitOfWork(new SimpleDataLayer(dict, dataStore))) {
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

            return new ThreadSafeDataLayer(dict, dataStore);
        }
        public static void InitializeService(DataServiceConfiguration config) {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.DataServiceBehavior.AcceptProjectionRequests = true;
        }
    }
}
