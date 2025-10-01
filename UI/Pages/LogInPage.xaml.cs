using System.Windows;
using System.Windows.Controls;

namespace UI;

public partial class LogInPage : Page
{
    public LogInPage()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string password = PasswordBox.Password;
        
        if (LogInCheck(login, password))
        {
            NavigationService?.Navigate(new MainPage());
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль");
        }
    }

    private bool LogInCheck(string login, string password)
    {
        return true; //(login == "admin" && password == "123");
    }
}