using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewFeatureApplication.Models;
using NewFeatureApplication.Repository;
using NewFeatureApplication.ViewModels;

namespace NewFeatureApplication.Controllers {
    [Route ("api/Departments")]
    public class DepartmentsController : Controller {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentsController> _Ilogger;

        public DepartmentsController (IDepartmentRepository repository,
                IMapper mapper,
                ILogger<DepartmentsController> logger) {
                _repository = repository;
                _mapper = mapper;
                _Ilogger = logger;
            }
            [HttpGet]
        public async Task<IActionResult> Get () {
            var getDepartments = await _repository.GetDepartmentsAsync ();
            return Ok (_mapper.Map<IEnumerable<DepartmentVm>> (getDepartments));
        }

        [HttpGet ("{DepartmentId}", Name = "getDepartment")]
        public async Task<IActionResult> Get (Guid DepartmentId) {
            var getDepartments = await _repository.GetDepartmentAsync (DepartmentId);
            return Ok (_mapper.Map<DepartmentVm> (getDepartments));
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CreateDepartment entity) {
            if (!ModelState.IsValid) {
                return BadRequest ();
            }
            var addDepartmentEntity = _mapper.Map<Department> (entity);
            await _repository.InsertDepartmentAsync (addDepartmentEntity);
            return Created ("getDepartment", null);
        }
    }
}