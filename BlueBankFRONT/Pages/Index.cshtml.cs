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
        /// Metodo para listar todos los objetos de la tabla TramitesCertificadoTransportador
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

        public IActionResult OnPostCrearCuenta(Cuenta Cuenta)
        {
            Cuenta cuenta = new Cuenta();
            ObjectResult result;
            try
            {
                RestClient client = new RestClient(Environment.GetEnvironmentVariable("BlueBankApi") + "Cuentas");
                client.Timeout = 10000;
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddBody(request.JsonSerializer.Serialize(Cuenta));
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
        #endregion
    }
}
