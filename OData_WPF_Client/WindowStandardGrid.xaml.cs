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
using System.Windows.Shapes;
using OData_WPF_Client.MyXpoDataServiceReference;
using System.Data.Services.Client;

namespace OData_WPF_Client {
    /// <summary>
    /// Interaction logic for WindowStandardGrid.xaml
    /// </summary>
    public partial class WindowStandardGrid : Window {
        public WindowStandardGrid() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //MyXpoDataService ctx = new MyXpoDataService(new Uri("http://localhost:50672/MyXpoDataService.svc"));
            //DataServiceQuery<Person> query = ctx.CreateQuery<Person>("Person");

            //System.Windows.Data.CollectionViewSource personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
            //// Load data by setting the CollectionViewSource.Source property:
            //personViewSource.Source = query.Execute();
            //personViewSource.View.MoveCurrentToFirst();
        }
    }
}
