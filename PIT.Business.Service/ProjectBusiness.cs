﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    [Export(typeof(IProjectBusiness))]
    public class ProjectBusiness : IProjectBusiness
    {
        private readonly IProjectClient _projectClient;

        [ImportingConstructor]
        public ProjectBusiness(IClientProvider clientProvider)
        {
            _projectClient = clientProvider.ProjectClient;
        }

        public Project GetById(int id)
        {
            return _projectClient.GetProject(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectClient.GetProjects();
        }

        public void Create(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}