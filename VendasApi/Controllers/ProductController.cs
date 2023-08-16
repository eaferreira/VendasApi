using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using VendasApi.Models;
using VendasApi.Services;
using VendasApi.Utils;

namespace VendasApi.Controllers
{
    public class ProductController : BaseController
    {
        protected readonly ProductService _service;
        public ProductController() 
        {
            _service = new ProductService();
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

        [HttpGet]
        [Route("Categories")]
        public IActionResult GetCategories()
        {
            try
            {
                Result result = _service.GetCategories();

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
