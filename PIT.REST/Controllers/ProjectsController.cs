﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PIT.REST.Data.Entities;
using PIT.REST.Data.Repositories.Contracts;
using PIT.REST.Models;
using PIT.REST.Models.Factories;

namespace PIT.REST.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly IModelFactory _modelFactory;
        private readonly IRepository<Project> _repository;

        public ProjectsController(IRepository<Project> projectRepository, IModelFactory modelFactory)
        {
            _repository = projectRepository;
            _modelFactory = modelFactory;
        }

        // GET api/<controller>
        public IEnumerable<ProjectModel> Get()
        {
            IQueryable<Project> projects = _repository.GetAll();
            return projects.ToList().Select(p => _modelFactory.CreateProject(p));
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Project project = _repository.Get(id);
                if (project.Exists())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _modelFactory.CreateProject(project));
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] ProjectModel projectModel)
        {
            try
            {
                Project project = _modelFactory.ParseProject(projectModel);
                Project responseModel = _repository.Create(project);
                return Request.CreateResponse(HttpStatusCode.Created, _modelFactory.CreateProject(responseModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] ProjectModel projectModel)
        {
            try
            {
                Project project = _modelFactory.ParseProject(projectModel);
                Project responseModel = _repository.Update(project);
                return Request.CreateResponse(HttpStatusCode.OK, responseModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Project responseModel = _repository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, responseModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}