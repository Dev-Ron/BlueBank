using BlueBankAPI.DataAccess;
using BlueBankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasController : ControllerBase
    {
        private BlueBankContext _dbContext;

        public CuentasController(BlueBankContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ObjectResult resultado;
            try
            {
                resultado = StatusCode(StatusCodes.Status200OK, _dbContext.Cuenta.ToList());
            }
            catch (Exception e)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return resultado;
        }

        // GET api/<CuentaController>/5
        [HttpGet("{NumeroCuenta}")]
        public IActionResult Get(string NumeroCuenta)
        {
            ObjectResult resultado;
            try
            {
                resultado = StatusCode(StatusCodes.Status200OK, _dbContext.Cuenta.FirstOrDefault(r => r.NumeroCuenta == NumeroCuenta));
            }
            catch (Exception e)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return resultado;
        }

        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult Post([FromBody] Cuenta cuenta)
        {
            ObjectResult resultado;
            try
            {
                cuenta.Persona = _dbContext.Persona.FirstOrDefault(r => r.Id == cuenta.Persona.Id);
                _dbContext.Add(cuenta);
                _dbContext.SaveChanges();
                resultado = StatusCode(StatusCodes.Status201Created, cuenta);
            }
            catch (Exception e)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return resultado;
        }

        // POST api/<CuentaController>
        [HttpPost("GenerarMovimiento")]
        public IActionResult Post(Movimiento movimiento)
        {
            ObjectResult resultado;
            try
            {
                Cuenta cuenta = _dbContext.Cuenta.FirstOrDefault(r => r.NumeroCuenta == movimiento.Cuenta.NumeroCuenta);
                cuenta.Valor += movimiento.Valor;
                _dbContext.SaveChanges();

                _dbContext.Add(movimiento);
                _dbContext.SaveChanges();

                resultado = StatusCode(StatusCodes.Status201Created, movimiento);
            }
            catch (Exception e)
            {
                resultado = StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return resultado;
        }
    }
}
