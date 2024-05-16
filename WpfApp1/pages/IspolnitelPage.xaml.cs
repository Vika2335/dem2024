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

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для IspolnitelPage.xaml
    /// </summary>
    public partial class IspolnitelPage : Page
    {
        public IspolnitelPage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            mainWindow.frame.Navigate(new Login());
            mainWindow.Title = "Авторизация";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.Zajavka.ToList();

            table.ItemsSource = Singleton.DB.Zajavka.Local;
        }
    }
}
