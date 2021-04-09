using BlueBankFRONT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlueBankFRONT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        #region Cuenta
        /// <summary>
        /// Metodo para buscar una cuenta registrada por su Numero de cuenta
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostConsultarCuenta(string NumeroCuenta)
        {
            Cuenta cuenta = new Cuenta();
            ObjectResult result;
            try
            {
                RestClient client = new RestClient(Environment.GetEnvironmentVariable("BlueBankApi") + "Cuentas/" + NumeroCuenta);
                client.Timeout = 10000;
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    cuenta = JsonConvert.DeserializeObject<Cuenta>(response.Content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result = StatusCode(StatusCodes.Status500InternalServerError, response.Content);
                }

                result = StatusCode(StatusCodes.Status200OK, (cuenta));
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Error al buscar cuenta");
                result = StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return result;
        }
        /// <summary>
        /// Crear una cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public IActionResult OnPostCrearCuenta(Cuenta cuenta)
        {
            
            ObjectResult result;
            try
            {
                RestClient client = new RestClient(Environment.GetEnvironmentVariable("BlueBankApi") + "Cuentas");
                client.Timeout = 10000;
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddJsonBody((cuenta));
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    cuenta = JsonConvert.DeserializeObject<Cuenta>(response.Content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result = StatusCode(StatusCodes.Status500InternalServerError, response.Content);
                }

                result = StatusCode(StatusCodes.Status200OK, (cuenta));
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Error al buscar cuenta");
                result = StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return result;
        }

        /// <summary>
        /// Crear una movimiento
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public IActionResult OnPostEnviarMovimiento(Movimiento movimiento)
        {
            ObjectResult result;
            try
            {
                movimiento.FechaMovimiento = DateTime.Now;

                RestClient client = new RestClient(Environment.GetEnvironmentVariable("BlueBankApi") + "Cuentas/GenerarMovimiento");
                client.Timeout = 10000;
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddJsonBody(movimiento);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    movimiento = JsonConvert.DeserializeObject<Movimiento>(response.Content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    result = StatusCode(StatusCodes.Status500InternalServerError, response.Content);
                }

                result = StatusCode(StatusCodes.Status200OK, (movimiento));
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Error al buscar cuenta");
                result = StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return result;
        }
        #endregion
    }
}
