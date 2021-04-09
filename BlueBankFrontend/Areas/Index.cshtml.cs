using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBankFrontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace BlueBankFrontend.Areas
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            
        }
        public void OnGet()
        {
        }

        #region Certificados
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
        #endregion
    }
}
