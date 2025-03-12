using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using UniversityManager.Models;
using UniversityManager.ViewModels;

namespace UniversityManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    public void showLogin(object sender, RoutedEventArgs args)

    {

    }
}