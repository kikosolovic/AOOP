using Avalonia.Controls;
using Avalonia.Interactivity;

namespace UniversityManager.Views;

public partial class CustomMessageBox : Window
{
    public CustomMessageBox()
    {
        InitializeComponent();
    }

    private void OnOkClick(object? sender, RoutedEventArgs e)
    {
        this.Close(); // Close the popup when "OK" is clicked
    }
}
