using Avalonia.Controls;
using Avalonia.Interactivity;

namespace UniversityManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void showLogin(object sender, RoutedEventArgs args)

    {
        var loginWindow = new Login();
        loginWindow.Show();

        this.Close();

    }
}