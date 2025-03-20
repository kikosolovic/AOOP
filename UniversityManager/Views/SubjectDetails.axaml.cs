using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UniversityManager.ViewModels;

namespace UniversityManager.Views;

public partial class SubjectDetails : UserControl
{
    public SubjectDetails()
    {
        InitializeComponent();
        DataContext = new SubjectDetailsViewModel();
    }
}