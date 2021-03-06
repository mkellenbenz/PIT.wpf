﻿using PIT.Business;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Issues
{
    public class IssueViewModel : ViewModel<Issue>
    {
        public IssueViewModel(Issue issue)
        {
            Issue = issue;
        }

        public Issue Issue { get; set; }

        public int Id
        {
            get { return Issue.Id; }
        }

        public string IssueNumber
        {
            get { return string.Format("#{0}", Issue.Id); }
        }

        public string Short
        {
            get { return Issue.Short; }
            set
            {
                Issue.Short = value;
                NotifyOfPropertyChange(() => Short);
            }
        }

        public string Description
        {
            get { return Issue.Description; }
            set
            {
                Issue.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public IssueStatus Status
        {
            get { return Issue.Status; }
            set
            {
                Issue.Status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }
    }
}