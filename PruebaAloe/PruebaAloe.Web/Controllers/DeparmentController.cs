using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAloe.Core.Domain;
using PruebaAloe.Services.Contract;

namespace PruebaAloe.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService) => this.departmentService = departmentService;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await departmentService.GetAll());

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetAll(int id) => Ok(await departmentService.GetById(id));

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await departmentService.Create(department));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await departmentService.Update(department, department.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await departmentService.Delete(department.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }
    }
}
