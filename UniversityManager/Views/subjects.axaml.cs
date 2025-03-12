using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UniversityManager.ViewModels;

namespace UniversityManager.Views;

public partial class Subjects : Window
{
    public Subjects()
    {
        InitializeComponent();
        DataContext = new SubjectsViewModel();
    }
}