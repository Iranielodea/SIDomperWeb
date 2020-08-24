using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            //  65528
            var app = new ChamadoApp();
            var model = app.ObterPorId(65528);

            foreach (var ocorrencia in model.ChamadoOcorrencias)
            {
                var colaborador = new ChamadoOcorrColaboradorViewModel();
                //var colaborador = new ChamadoOcorrenciaColaborador();
                colaborador.HoraFim = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                colaborador.HoraInicio = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                colaborador.ChamadoOcorrenciaId = ocorrencia.Id;
                colaborador.TotalHoras = 1;
                colaborador.UsuarioId = 21;
                ocorrencia.ChamadoOcorrenciaColaboradores.Add(colaborador);
            }
            var temp = app.Salvar(model, 1, false);

            //var model = servico.ObterPorId(65528);
            //foreach (var ocorrencia in model.ChamadoOcorrencias)
            //{
            //    foreach (var colaborador in ocorrencia.ChamadoOcorrenciaColaboradores)
            //    {
            //        colaborador.Id = 0;
            //        colaborador.ChamadoOcorrenciaId =
            //    }
            //}

            //var lista = new List<string>();
            //var servico = new ClienteServico();
            //try
            //{

            //    lista = servico.ImportarXml(@"C:\Projetos\Domper\SIDomperWeb\Banco\11.xml");
            //    if (lista.Count > 0)
            //    {
            //        foreach (var item in lista)
            //        {
            //            Console.WriteLine(item);
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //    //Console.WriteLine("Erro: " + ex.Message);
            //    //foreach (var item in lista)
            //    //{
            //    //    Console.WriteLine(item);
            //    //}
            //}

            Console.WriteLine("Fim ----------------------");
            Console.Read();
        }
    }
}
