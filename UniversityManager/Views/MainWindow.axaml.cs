using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using UniversityManager.Models;

namespace UniversityManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void showLogin(object sender, RoutedEventArgs args)

    {
        userManager userManager = new userManager();
        userManager.loadData();
        Console.WriteLine(userManager.teachers[1].Name);

    }
}