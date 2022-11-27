using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Shapes;
using NoteApp.BUS;
using NoteApp.DTO;
using Prism.Ioc;
using Prism.Modularity;

namespace NoteApp.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        AccountBLL bllAccounts;
        DataTable dt;
        List<AccountDTO> listAccounts;
        static string loggedInUser;
        public Login()
        {
            InitializeComponent();
            bllAccounts = new AccountBLL();
            dt = bllAccounts.getAllAccounts();
            listAccounts = new List<AccountDTO>();
            foreach (DataRow row in dt.Rows)
            {
                AccountDTO acc = new AccountDTO();
                acc.Username = row["Username"];
                acc.Password = row["Password"];
                listAccounts.Add(acc);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChkLoginForm())
                {
                    if (ChkLogin(txtUser.Text.ToString(), txtPass.Password.ToString()))
                    {
                        loggedInUser = txtUser.Text.ToString();
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Unknown username or password", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show( string.Format("Unknown error occurred {0}", exp.ToString()), "Notice", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AccountDTO acc = new AccountDTO();
                acc.Username = txtCreateUser.Text;
                acc.Password = txtCreatePass.Password.ToString();
                listAccounts.Add(acc);
                bllAccounts.AddAccount(acc);
                DialogResult = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(string.Format("Unknown error occurred {0}", exp.ToString()), "Notice", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnCreate_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ChkLoginForm()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Please enter username", "Notice", MessageBoxButton.OK,
                    MessageBoxImage.Stop);
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Please enter your password", "Notice", MessageBoxButton.OK,
                    MessageBoxImage.Stop);
                txtPass.Focus();
                return false;
            }
            return true;
        }

        private bool ChkLogin(string userName, string passWord)

        {
            foreach (AccountDTO acc in listAccounts)
            {
                if (acc.Username.ToString() == userName)
                {
                    return acc.Password.ToString() == passWord;
                }
            }
            return false;
        }
    }
}
