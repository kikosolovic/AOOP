using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UniversityManager.ViewModels;

namespace UniversityManager.Views;

public partial class SubjectList : UserControl
{
    public SubjectList()
    {
        InitializeComponent();
        DataContext = new SubjectListViewModel();
    }
}