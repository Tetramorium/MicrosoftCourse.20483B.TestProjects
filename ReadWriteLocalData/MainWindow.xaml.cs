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
            string str = this.tb_LogText.Text;

            if (!string.IsNullOrWhiteSpace(str))
            {
                ldc.Write(new Log(str));
                this.tb_LogText.Clear();
                ScrollListBoxToBottom(this.lb_Logs);
            }
            else
                MessageBox.Show("Please enter some text for the log", "Log can't be empty", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // ListBox Scroll to end automatically
        // https://stackoverflow.com/a/28433208

        private void ScrollListBoxToBottom(ListBox _lb)
        {
            if (VisualTreeHelper.GetChildrenCount(_lb) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(_lb, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
