using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EstebanJimenezEFP6App.Models
{
    public class AskDTO
    {
        public RestRequest Request { get; set; }
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        //Funciones 

        public async Task<AskDTO> GetAskInfo(string Pask)
        {
            try
            {


                //usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = String.Format("Asks/GetInfoByask?Pask={0}", Pask);

                //armamos la rura completa al endpoint en el API
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<AskDTO>>(response.Content);
                    var item = list[0];
                    return item;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;

                throw;
            }

        }


    }
}

