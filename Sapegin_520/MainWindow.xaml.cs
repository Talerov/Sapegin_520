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

namespace Sapegin_520
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e) 
        {
            string username = txtUsername.Text; 
            string password = txtPassword.Password; 

            Users users = Model.Users.FirstOrDefault(u => u.Login == username && u.Password == password); 

            if (users != null) 
            {
                if (users.Role == "admin") 
                {
                    AdminPage adminPage = new AdminPage(); 
                    adminPage.Show(); 
                    Close(); 
                }
            }
            else 
            {
                MessageBox.Show("Неверно введен логин или пароль."); 
            }
        }
    }
}
