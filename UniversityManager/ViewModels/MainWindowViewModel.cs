using UniversityManager.Models;
using ReactiveUI;
using System.Reactive;
using UniversityManager.Views;
namespace UniversityManager.ViewModels;

public partial class MainWindowViewModel : ReactiveObject
{
    public string Greeting { get; } = $"Welcome {userManager.currentUser?.Name}, you are logged in as {userManager.currentUser?.Role}!";

    public bool isStudent => userManager.currentUser?.Role == "student";
    public bool isTeacher => userManager.currentUser?.Role == "teacher";

    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }
    public void showSubjects()
    {
        CurrentView = new Subjects();
    }
}
