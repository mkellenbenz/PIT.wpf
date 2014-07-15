﻿using System.Collections.ObjectModel;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.SampleData
{
    class SampleIssueAreaViewModel : PropertyChangedBase, IIssueAreaViewModel
    {
        public IIssueHeaderAreaViewModel IssueHeaderView { get; set; }
        public ObservableCollection<IssueViewModel> Issues { get; set; }

        public SampleIssueAreaViewModel()
        {
            Issues = new ObservableCollection<IssueViewModel>
            {
                new IssueViewModel
                (
                    new Issue()
                    {
                        Description = "Description 1"
                    }
                ),
                new IssueViewModel
                (
                    new Issue()
                    {
                        Description = "Description 2",
                    }
                )
            };
        }
    }
}