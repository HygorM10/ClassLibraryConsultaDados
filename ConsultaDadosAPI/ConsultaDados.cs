using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsultaDadosAPI
{
    //Consulta CEP Via API Correios
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("F30B03F5-5B81-447F-9930-F149F225FCD0")]
    [ComVisible(true)]
    public interface IConsultaCEP
    {
        DadosCEP ConsultaDadosCEP(string zipCode);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComSourceInterfaces(typeof(IConsultaCEP))]
    [Guid("94CB0699-3887-43DE-A3F0-82F9BE8612A0")]
    public class ConsultaCEP
    {
        readonly HttpClient _httpClient;
        string apiCEP = "https://viacep.com.br/ws";
        public ConsultaCEP()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public DadosCEP Consulta(string zipCode)
        {
            var dados = new DadosCEP();

            try
            {

                HttpResponseMessage response = _httpClient.GetAsync($"{apiCEP}/{zipCode}/json").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(result))
                    {
                        dados = JsonConvert.DeserializeObject<DadosCEP>(result);
                    }
                    else
                        dados = null;

                }
                else
                    dados = null;

            }
            catch (Exception)
            {
                dados = null;
            }

            return dados;
        }
    }

    //Consulta CNPJ Via API ReceitaWS
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("E3EA5B21-EFE2-474F-B0DF-3F745DDAA053")]
    [ComVisible(true)]
    public interface IConsultaCNPJ
    {
        DadosCNPJ ConsultaDadosCNPJ(string inscricao);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComSourceInterfaces(typeof(IConsultaCNPJ))]
    [Guid("B46E5A0E-1050-4FE5-9A79-3C896FB3408F")]
    public class ConsultaCNPJ
    {
        readonly HttpClient _httpClient;
        string apiCNPJ = "https://www.receitaws.com.br/v1/cnpj";
        public ConsultaCNPJ()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public DadosCNPJ Consulta(string inscricao)
        {
            var dados = new DadosCNPJ();

            try
            {

                HttpResponseMessage response = _httpClient.GetAsync($"{apiCNPJ}/{inscricao}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(result))
                    {
                        dados = JsonConvert.DeserializeObject<DadosCNPJ>(result);
                    }
                    else
                        dados = null;

                }
                else
                    dados = null;


            }
            catch (Exception e)
            {
                if(e.Data = TimeoutException)
                dados = null;
            }

            return dados;

        }
    }
}
