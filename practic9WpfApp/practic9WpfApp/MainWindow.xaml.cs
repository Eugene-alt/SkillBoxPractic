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

namespace practic9WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StringNagibator stringNagibator = new StringNagibator();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> list;

            StringNagibator stringNagibator = new StringNagibator();
            string text = TextBoxList.Text;
            list = stringNagibator.StringSplit(text);

            ListDb.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringNagibator stringNagibator = new StringNagibator();
            string text = TextBoxReverse.Text;

            LabelReverse.Content = stringNagibator.ReverseString(text);
        }
    }
}
