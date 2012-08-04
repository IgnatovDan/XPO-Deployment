=== Pre requisites ===
Place all DevExpress assemblies to the '_Dlls' folder or install a complete DevExpress installation.
Currently, the DXperience v12.2 is required.

The MyXpoClassLibrary\Constants.cs file contains a connectionstring to a database:
string DatabaseConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.\\SQLEXPRESS;Initial Catalog=XpoDeployment";

Use the _CreateDatabase console application to create the database with two related tables: Person and Product.

=== Direct database connection ===
The DirectDBConnect_Console project demonstrates how to use XPO to read records as .Net objects directly from a database (by a connectionstring).

== WCF ===
The MyXpoClassLibrary\Constants.cs file contains an Url to open a service host:
        public const string WCF_Server_Uri = "http://localhost:59338/DataService";

The WCF_Client_Console and WCF_Server_Console projects demonstrates how to provide access to the same information via a WCF service and read it in a simple console client application.

=== OData ===
The MyXpoClassLibrary\Constants.cs file contains an Url to open a service:
        public const string OData_Server_Uri = "http://localhost:50672/MyXpoDataService.svc";

The OData_Server project publishes access to the created database via an OData service.

The OData_Server_InMemory project is introduced to simplify deployment and testing and doesn't use a real database. Instead, a DataSet object is used to hold tables and records and manage incoming read/update requests.

The OData_Client_Console is a .Net console application that connects to the published OData service via Linq and a customized DataServiceQuery object.

The OData_WPF_Client project is a .NET WPF application that contains DevExpress DXGrid control and a standard Grid control. Both controls are bound to the OData service and shows the same information.

The OData_Client_Html_jQuery_JSON project demonstrates how to connect to a published OData service and show received objects in a browser.