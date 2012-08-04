using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistentClassesLibrary {
    public class Constants {
        public const string DatabaseConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.\\SQLEXPRESS;Initial Catalog=XpoDeployment";
        public const string WCF_Server_Uri = "http://localhost:59338/DataService";
        public const string OData_Server_Uri = "http://localhost:50672/MyXpoDataService.svc";
    }
}
