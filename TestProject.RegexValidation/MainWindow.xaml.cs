using System;
using System.Collections.Generic;
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
using TestProject.RegexValidation.Controller;

namespace TestProject.RegexValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_TestOnlyNumbers(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.tb_OnlyNumbers.Text))
            {
                if (ValidationController.OnlyNumbers(this.tb_OnlyNumbers.Text.Trim()))
                    MessageBox.Show("These are only numbers!");
                else
                    MessageBox.Show("These are not only numbers!");
            }
            else
            {
                MessageBox.Show("These are not numbers...");
            }
        }

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ValidationController.OnlyNumbers(e.Text);
        }

        private void bt_TestPassword_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationController.IsValidPassword(this.pb_Password.Password))
                MessageBox.Show("Valid password!");
            else
                MessageBox.Show("Password must be between 8 and 15 characters and requires one special character, one uppercase, one lowercase and one number!");
        }

        private void bt_TestParseInt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ValidationController.ParseInt(this.tb_TestParseInt.Text).ToString());       
        }
    }
}
