namespace Testes
{
    public class CRUD
    {
        //string URL = "http://localhost:64735/api/";

        //public ProdutoViewModel GetId(int id, int idUsuario)
        //{
        //    string URI = URL + "produto/" + id.ToString() + "?idusuario=" + idUsuario;
        //    var operacao = new Operacao<ProdutoViewModel>();
        //    return operacao.First(URI);
        //}

        //public ProdutoViewModel[] GetAll()
        //{
        //    string URI = URL + "produto/?campo=prod_nome&texto=";
        //    var operacao = new Operacao<ProdutoViewModel>();
        //    return operacao.GetAll(URI).ToArray();
        //}
        
        //public ProdutoViewModel AddProduto()
        //{
        //    string URI = URL + "produto";
        //    ProdutoViewModel model = new ProdutoViewModel();
        //    model.Id = 0;
        //    model.Codigo = 16;
        //    model.Nome = "IRANI-16";
        //    model.Ativo = true;

        //    var operacao = new Operacao<ProdutoViewModel>();
        //    return operacao.Insert(URI, model);
        //}

        //public ProdutoViewModel Alterar()
        //{
        //    string URI = URL + "produto";
        //    ProdutoViewModel model = new ProdutoViewModel();
        //    model.Id = 40;
        //    model.Codigo = 9;
        //    model.Nome = "IRANI-9";
        //    model.Ativo = true;

        //    var operacao = new Operacao<ProdutoViewModel>();
        //    return operacao.Update(URI, model);
        //}

        //public ProdutoViewModel Excluir(int id, int idUsuario)
        //{
        //    string URI = URL + "produto/" + id.ToString() + "?idusuario=" + idUsuario;

        //    var operacao = new Operacao<ProdutoViewModel>();
        //    return operacao.Delete(URI);
        //}
    }

    public class Operacao<T>
    {
        //public T Insert(string uri, object model)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var serializedObj = JsonConvert.SerializeObject(model);
        //            var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.PostAsync(uri, content).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T>(retorno);
        //            }
        //            else
        //                throw new Exception("Erro: " + response.StatusCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public T Update(string uri, object model)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var serializedObj = JsonConvert.SerializeObject(model);
        //            var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.PutAsync(uri, content).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T>(retorno);
        //            }
        //            else
        //                throw new Exception("Erro: " + response.StatusCode);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public T First(string uri)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            HttpResponseMessage response = client.GetAsync(uri).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T>(retorno);
        //            }
        //            else
        //            {
        //                throw new Exception("Erro: " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public T[] GetAll(string uri)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            HttpResponseMessage response = client.GetAsync(uri).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T[]>(retorno);
        //            }
        //            else
        //            {
        //                throw new Exception("Erro : " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public T Delete(string uri)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(uri);
        //            HttpResponseMessage response = client.DeleteAsync(uri).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T>(retorno);
        //            }
        //            else
        //            {
        //                throw new Exception("Falha ao excluir o produto  : " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public T Excluir(string uri)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(uri);
        //            HttpResponseMessage response = client.DeleteAsync(uri).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var retorno = response.Content.ReadAsStringAsync().Result;
        //                return JsonConvert.DeserializeObject<T>(retorno);
        //            }
        //            else
        //            {
        //                throw new Exception("Falha ao excluir o produto  : " + response.StatusCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
