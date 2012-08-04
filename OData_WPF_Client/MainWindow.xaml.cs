using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OData_WPF_Client.MyXpoDataServiceReference;
using System.Data.Services.Client;

namespace OData_WPF_Client {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public const string ODataServerAddress = "http://localhost:50672/MyXpoDataService.svc";
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            WindowDXGrid wnd = new WindowDXGrid();
            CollectionViewSource viewSource = ((System.Windows.Data.CollectionViewSource)(wnd.FindResource("personViewSource")));
            wnd.Loaded += (sender1, e1) => {
                MyXpoDataService ctx = new MyXpoDataService(new Uri(ODataServerAddress));
                var persons = from p in ctx.CreateQuery<Person>("Person") select p;

                viewSource.Source = persons;
                viewSource.View.MoveCurrentToFirst();
                
            };
            wnd.Show();
        }

        void wnd_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            WindowStandardGrid wnd = new WindowStandardGrid();
            CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(wnd.FindResource("personViewSource")));
            wnd.Loaded += (sender1, e1) => {
                MyXpoDataService ctx = new MyXpoDataService(new Uri(ODataServerAddress));
                DataServiceQuery<Person> query = ctx.CreateQuery<Person>("Person");
                source.Source = query.Execute();
                source.View.MoveCurrentToFirst();
            };
            wnd.Show();
        }
    }
}
