using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using VendasApi.Models;
using VendasApi.Services;
using VendasApi.Utils;

namespace VendasApi.Controllers
{
    public class EmployeeController : BaseController
    {
        protected readonly EmployeeService _service;
        public EmployeeController()
        {
            _service = new EmployeeService();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                Result result = _service.GetAll();

                if (result.Value.IsNullOrEmpty())
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result.Value);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetId(), $"Erro interno do servidor. {ex.Message}");
            }
        }
    }
}
