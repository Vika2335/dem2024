using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            mainWindow.frame.Navigate(new Login());
            mainWindow.Title = "Авторизация";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tip.Text == "" || number.Text == "" || information.Text == "" || prioritet.Text == "" || date.SelectedDate == null || status.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            Singleton.DB.Zajavka.Add(new Zajavka()
            {
                Tip_neispravnosti = tip.Text,
                Serijni_number = number.Text,
                Information = information.Text,
                Priopitet = prioritet.Text,
                Date_create = (DateTime)date.SelectedDate,
                ID_status = status.SelectedIndex
            });

            if(MessageBox.Show("Сохранение", "Сохранить изменения?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Singleton.DB.SaveChanges();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            status.ItemsSource = Singleton.DB.Status.ToList();
        }
    }
}
