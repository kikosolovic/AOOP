using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using ReactiveUI;
using UniversityManager.Models;
using UniversityManager.Views;

namespace UniversityManager.ViewModels
{
    public partial class SubjectsViewModel : ReactiveObject
    {
        private ObservableCollection<Models.Subject> _subjectList;

        public ObservableCollection<Models.Subject> SubjectList
        {
            get => _subjectList;
            set => this.RaiseAndSetIfChanged(ref _subjectList, value);
        }

        public SubjectsViewModel()

        {
            SubjectList = new ObservableCollection<Models.Subject>(
                userManager.subjects
            );
        }
    }
}