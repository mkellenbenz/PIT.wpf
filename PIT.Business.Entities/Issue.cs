﻿namespace PIT.Business.Entities
{
    public class Issue : Entity
    {
        public string Short { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }

        public Project Project { get; set; }
    }
}
