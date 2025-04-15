using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
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
                    User userModel = CoreConnections.DB.Users.FirstOrDefault(u =>
                    u.Login == TbLogin.Text &&
                    u.Password == PbPassword.Password);



                    if (userModel != null)
                    {
                        MessageBox.Show($"{userModel.Login} - выполнен успешный вход!",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных"
                            , "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
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


        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreConnections.CoreFrame.Navigate(new MainRegistrationPage());
        }
    }
}
