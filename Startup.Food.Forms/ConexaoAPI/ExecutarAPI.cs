using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Startup.Food.Repositorio.Entidade;

using System.Net.Http;
using System.Net.Http.Headers;


using System.Data;
using System.Collections.ObjectModel;
using System.Net;

namespace Startup.Food.Forms.ConexaoAPI
{
    public class ExecutarAPI
    {


        //const string _conexaoAPI = "http://apimstargerenciamento.us-east-2.elasticbeanstalk.com/api/";
        const string _conexaoAPI = "https://localhost:44324/api/";
        
        public HttpResponseMessage POST(Object Entidade = null, string _url = "")
        {
            string requestMessage;
            StringContent content;
            HttpResponseMessage responseMessage;

            try
            {
                var Token = GetToken();

                if (Entidade != null) {
                    requestMessage = JsonConvert.SerializeObject(Entidade);
                    content = new StringContent(requestMessage, Encoding.UTF8, "application/json");
                }
                else
                {
                    content = null;
                }

                

                using (var cliente = new HttpClient())
                {

                    cliente.DefaultRequestHeaders.Authorization =
                                    new AuthenticationHeaderValue("Bearer", Token);

                    if (Entidade != null)
                        responseMessage = cliente.PostAsync(_conexaoAPI + _url, content).Result;
                    else
                        responseMessage = cliente.PostAsync(_conexaoAPI + _url,null).Result;

                    if (!responseMessage.IsSuccessStatusCode)
                        throw new Exception("Erro retorno API:" + _conexaoAPI + _url);
                }

                return responseMessage;
            }catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    if (httpResponse.StatusCode.ToString() == "401")
                    {
                        throw e;
                    }
                }
                throw e;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                requestMessage = null;
                content = null;
                responseMessage = null;
            }
            
        }


        public string GetToken()
        {
            string requestMessage;
            StringContent content;
            HttpResponseMessage responseMessage;

            try
            {
                object obj = new { Usuario =  "admin", Senha = "admin"};


                requestMessage = JsonConvert.SerializeObject(obj);
                content = new StringContent(requestMessage, Encoding.UTF8, "application/json");

                using (var cliente = new HttpClient())
                {

                    responseMessage = cliente.PostAsync(_conexaoAPI + "Token/RequestToken", content).Result;

                    if (!responseMessage.IsSuccessStatusCode)
                        throw new Exception("Erro retorno API:" + _conexaoAPI + "RequestToken");
                }

                var objList = JsonConvert.DeserializeObject<JObject>(responseMessage.Content.ReadAsStringAsync().Result);


                return objList["token"].ToString();
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    if (httpResponse.StatusCode.ToString() == "401")
                    {
                        throw;
                    }
                }
                throw e;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                requestMessage = null;
                content = null;
                responseMessage = null;
            }

        }
    }
}
