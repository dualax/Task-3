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
using WpfApp3.Core;

namespace WpfApp3.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainRegistrationPage.xaml
    /// </summary>
    public partial class MainRegistrationPage : Page
    {
        public MainRegistrationPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = CoreConnections.DB.Roles.ToList();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login) ||
               string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Ошибка ввода данных",
                    "Системное сообщение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            else
            {
                try
                {
                    CoreConnections.DB.Users.Add(new User()
                   {
                       Login.BtnLogin.Text,
                       Password = PbPassword.Password,
                       RoleID = Convert.ToInt32(CbRole.Text)
                   });
                    CoreConnections.DB.SaveChanges();
                    MessageBox.Show("Учетная запись создана",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    CoreConnections.CoreFrame.Navigate(new MainLoginPage());
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CoreConnections.CoreFrame.Navigate(new MainLoginPage());
        }
    }
}
