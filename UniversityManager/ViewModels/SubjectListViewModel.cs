using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Subjects;
using ReactiveUI;
using UniversityManager.Models;


namespace UniversityManager.ViewModels;

public class SubjectListViewModel
{
    public ObservableCollection<Models.Subject> MySubjects { get; set; }
    public ReactiveCommand<Models.Subject, Unit> EnrollCommand { get; }

    // Details command for handling details button clicks
    public ReactiveCommand<Models.Subject, Unit> DetailsCommand { get; }
    public ReactiveCommand<Unit, Unit> kokot { get; }


    public SubjectListViewModel()
    {
        userManager.loadData();
        MySubjects = new ObservableCollection<Models.Subject>(userManager.subjects);

        EnrollCommand = ReactiveCommand.Create<Models.Subject>(EnrollSubject);
        DetailsCommand = ReactiveCommand.Create<Models.Subject>(ViewSubjectDetails);
        kokot = ReactiveCommand.Create(AddSubject);
    }
    private void AddSubject()
    {
        Console.WriteLine("kokot");
    }
    private void EnrollSubject(Models.Subject subject)
    {
        // Add your logic for enrolling in the subject here
        Console.WriteLine($"Enrolled in: {subject.Name}");
    }

    private void ViewSubjectDetails(Models.Subject subject)
    {
        // Add your logic for viewing the subject details here
        Console.WriteLine($"Viewing details of: {subject.Name}");
    }

}
