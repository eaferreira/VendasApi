using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Net;
using VendasApi.Entities;
using VendasApi.Models;
using VendasApi.Services;
using VendasApi.Utils;

namespace VendasApi.Controllers
{
    public class SalesController : BaseController
    {
        protected readonly SalesService _service;
        public SalesController()
        {
            _service = new SalesService();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sales sales)
        {
            try
            {
                Result result = _service.Add(sales);

                if (result.IsError)
                {
                    return BadRequest(result.ErrorMessage);
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
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Result result = _service.GetById(id);

                if (result.Value.IsNullOrEmpty())
                {
                    return NoContent();
                }
                else if (result.IsError)
                {
                    return BadRequest(result.ErrorMessage);
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

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch([FromBody] Sales sales, int id)
        {
            try
            {
                Result result = _service.UpdateStatus(sales);

                if (result.IsError)
                {
                    return BadRequest(result.ErrorMessage);
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

        [HttpGet]
        [Route("PaymentStatus")]
        public IActionResult GetPaymentStatus()
        {
            try
            {
                Result result = _service.GetPaymentStatus();

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
