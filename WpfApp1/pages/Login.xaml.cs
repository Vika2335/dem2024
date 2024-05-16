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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = Singleton.DB.User.FirstOrDefault(u => u.Login == username.Text && u.Password == password.Password);

            if (username.Text == null || password.Password == null)
            {
                MessageBox.Show("Заполните обязательные поля!");
            }

            if (user == null) {
                MessageBox.Show("Пользователь не существует");
            }
            else
            {
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

                if(user.ID_role == 1)
                {
                    mainWindow.frame.Navigate(new IspolnitelPage());
                    mainWindow.Title = "Заявки";
                }
                if(user.ID_role == 2)
                {
                    mainWindow.frame.Navigate(new ClientPage());
                    mainWindow.Title = "Подать заявку";
                } 
            }

        }

    }
}
