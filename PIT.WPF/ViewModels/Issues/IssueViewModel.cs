﻿using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Issues
{
    public class IssueViewModel : ViewModel<Issue>
    {
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

        public User Developer
        {
            get { return Issue.Developer; }
            set
            {
                Issue.Developer = value;
                NotifyOfPropertyChange(() => Developer);
            }
        }

        public User Tester
        {
            get { return Issue.Tester; }
            set
            {
                Issue.Tester = value;
                NotifyOfPropertyChange(() => Tester);
            }
        }
    }
}