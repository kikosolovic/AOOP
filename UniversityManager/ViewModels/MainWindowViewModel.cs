using UniversityManager.Models;
using ReactiveUI;
using Avalonia.Controls;
using System.Reactive;
using UniversityManager.Views;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace UniversityManager.ViewModels;
public partial class MainWindowViewModel : ReactiveObject
{
    public string Greeting { get; } = $"Welcome {userManager.currentUser?.Name}, you are logged in as {userManager.currentUser?.Role}!";

    public bool isStudent => userManager.currentUser?.Role == "student";
    public bool isTeacher => userManager.currentUser?.Role == "teacher";
    public ReactiveCommand<Unit, Unit> ShowSubjectsCommand { get; }

    private UserControl _currentView;

    public UserControl CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }

    public MainWindowViewModel()
    {

        ShowSubjectsCommand = ReactiveCommand.Create(showSubjects);

        CurrentView = null;


    }

    public void showSubjects()
    {

        Console.WriteLine("showSubjects");
        CurrentView = new SubjectList();
    }

    public void showDetails()
    {
        CurrentView = new SubjectDetails();
    }
}