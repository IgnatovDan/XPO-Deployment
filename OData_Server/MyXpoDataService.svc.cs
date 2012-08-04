using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.ServiceModel;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using PersistentClassesLibrary;

namespace OData_Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyXpoDataService : XpoDataService {
        public MyXpoDataService() : base(new XpoContext("MyXpoDataService", "PersistentClassesLibrary", CreateDataLayer())) { }
        static IDataLayer CreateDataLayer() {
            DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(Person).Assembly);
            
            IDataStore store = XpoDefault.GetConnectionProvider(Constants.DatabaseConnectionString, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            return new ThreadSafeDataLayer(dict, store);
        }
        public static void InitializeService(DataServiceConfiguration config) {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.DataServiceBehavior.AcceptProjectionRequests = true;
        }
    }
}
