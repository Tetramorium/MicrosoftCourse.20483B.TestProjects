using ReadWriteLocalData.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadWriteLocalData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LocalDataController ldc;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ldc;

            this.ldc = new LocalDataController();

            ldc.Read();

            this.lb_Logs.ItemsSource = ldc.Logs;
        }

        private void bt_LogComment_Click(object sender, RoutedEventArgs e)
        {
            ldc.Write(DateTime.Now.ToString() + " - Test");

            ldc.Read();

            this.lb_Logs.ItemsSource = ldc.Logs;
        }
    }
}
