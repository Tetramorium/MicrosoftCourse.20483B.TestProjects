using ReadWriteLocalData.Controller;
using ReadWriteLocalData.Model;
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

            this.ldc = new LocalDataController();

            this.DataContext = ldc;

            ldc.Read();
        }

        private void bt_LogComment_Click(object sender, RoutedEventArgs e)
        {
            ldc.Write(new Log("Test"));
        }
    }
}
