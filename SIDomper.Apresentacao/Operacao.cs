using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Apresentacao
{
    public class Operacao<T>
    {
        public T Insert(string uri, object model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                        throw new Exception("Erro: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Update(string uri, object model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                        throw new Exception("Erro: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T First(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                    {
                        throw new Exception("Erro: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T[] GetAll(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T[]>(retorno);
                    }
                    else
                    {
                        throw new Exception("Erro : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Delete(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    HttpResponseMessage response = client.DeleteAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                    {
                        throw new Exception("Falha ao excluir o produto  : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T[] ObjetoToJSon(string uri, object model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T[]>(retorno);
                    }
                    else
                        throw new Exception("Erro: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
