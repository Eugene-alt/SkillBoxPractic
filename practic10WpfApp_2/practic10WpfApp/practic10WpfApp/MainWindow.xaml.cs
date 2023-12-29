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

namespace practic10WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedIndex = 0;
        BankWorker worker = new Consultant();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public string GetNewData()
        {
            return SelectedDataTextBlock.Text;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            Repository repository = new Repository();

            if(ConsultantRadioButton.IsChecked == true)
            {
                worker = new Consultant();
                NewClientStackPanel.IsEnabled = false;
            }
            else
            {
                worker = new Manager();
            }

            this.Title = $"Всего клиентов {Repository.clients.Count}";

            ListViewClients.ItemsSource = Repository.clients;
            ListViewClients.Items.Refresh();

            ConsultantRadioButton.IsEnabled = false;
            ManagerRadioButton.IsEnabled = false ;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDataStr = (DataComboBox.SelectedItem as TextBlock).Text;

            switch (selectedDataStr)
            {
                case "Имя":
                    SelectedDataTextBlock.Text = worker.LookName(selectedIndex);
                    break;
                case "Фамилия":
                    SelectedDataTextBlock.Text = worker.LookSurname(selectedIndex);
                    break;
                case "Отчество":
                    SelectedDataTextBlock.Text = worker.LookPatronimic(selectedIndex);
                    break;
                case "Паспортные данные":
                    SelectedDataTextBlock.Text = worker.LookPassport(selectedIndex);
                    break;
                case "Номер телефона":
                    SelectedDataTextBlock.Text = worker.LookPhoneNumber(selectedIndex);
                    break;  
            }

            
        }

        private void ListViewClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            selectedIndex = ListViewClients.SelectedIndex;
            SelectDataLabel.Content = $"Выбери поле клиента {selectedIndex}";
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedDataStr = (DataComboBox.SelectedItem as TextBlock).Text;

            switch (selectedDataStr)
            {
                case "Имя":
                    worker.ChangeName(selectedIndex, GetNewData());
                    break;
                case "Фамилия":
                     worker.ChangeSurname(selectedIndex, GetNewData());
                    break;
                case "Отчество":
                    worker.ChangePatronimic(selectedIndex, GetNewData());
                    break;
                case "Паспортные данные":
                    worker.ChangePassport(selectedIndex, GetNewData());
                    break;
                case "Номер телефона":
                    worker.ChangePhoneNumber(selectedIndex, GetNewData());
                    break;
            }
            ListViewClients.Items.Refresh();
        }

        private void SortButtonClick(object sender, RoutedEventArgs e)
        {
            Client[] tempClients = new Client[Repository.clients.Count];
            for (int i = 0; i < tempClients.Length; i++)
            {
                tempClients[i] = Repository.clients[i];
            }

            Array.Sort(tempClients, (x, y) => String.Compare(x.Name, y.Name));

            for(int i = 0;i < tempClients.Length;i++)
            {
                Repository.clients[i] = tempClients[i];
                Repository.clients[i].Id = i;
                Repository.Serialize();
            }
            ListViewClients.Items.Refresh();
        }

        private void AddNewClientButtonClick(object sender, RoutedEventArgs e)
        {
            string name = NewClientNameTextBox.Text;
            string surname = NewClientSurnameTextBox.Text;
            string patronimic = NewClientPatronimicTextBox.Text;
            string phone = NewClientPhoneTextBox.Text;
            string passport = NewClientPassportTextBox.Text;

            if(!String.IsNullOrEmpty(name)&& !String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(patronimic)
                && !String.IsNullOrEmpty(phone) && !String.IsNullOrEmpty(passport)) // Если данные не пустые
            {
                worker.AddNewClient(name, surname, patronimic, phone, passport);
                ListViewClients.Items.Refresh(); 

                NewClientNameTextBox.Text = "";
                NewClientSurnameTextBox.Text = "";
                NewClientPatronimicTextBox.Text = "";
                NewClientPhoneTextBox.Text = "";
                NewClientPassportTextBox.Text = "";
            }
        }
    }
}
