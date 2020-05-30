using SIDomper.Servicos.Regras;
using System;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {

            //var chamado = new ChamadoOcorrenciaConsulta();
            //var servico = new ChamadoOcorrenciaServico();
            //var filtro = new ClienteFiltroViewModel();
            //filtro.Campo = "Cli_Nome";
            //filtro.Valor = "";
            //filtro.Restricao = 2;
            //var model = servico.Filtrar(filtro, 1);

            //var tt = servico.ObterPorId(1);




            var servico = new SolicitacaoServico();
            string permissao = "";
            var model = servico.Editar(1, 1705, ref permissao);

            Console.WriteLine("cliente: " + model.ClienteId);
            Console.WriteLine("cliente: " + model.Cliente.Nome);


            //Console.WriteLine("item: " + tt.Data + " - " + tt.DescricaoSolucao);

            //var model = servico.Filtrar(filtro, 23, "Cha_Cliente", "2259", true, EnumChamado.Chamado);



            //Console.WriteLine("============================ enter");
            //Console.ReadKey();

            //var servicoADO = new ChamadoADO();
            //var tt = servicoADO.ObterConsultaPorChamado(26501);
            //var model = servicoADO.ObterConsultaPorChamado(26505);

            //var servico = new ChamadoApp();
            //var servico = new ChamadoServico();
            //var model = servico.ObterPorId(64512);

            //model.Contato = "IRANI";

            //Console.WriteLine(model.Id + " - " + model.Contato + " - " + model.DataAbertura);

            //var serv = new ChamadoOcorrenciaServico();
            //var model = serv.ObterConsultaPorChamado(26505);

            int contador = 1;

            //Console.WriteLine("======= ocorrencias =====================");
            //foreach (var item in model)
            //{
            //if (contador == 1)
            //{
            //    item.Documento = "DOC-IRANI";
            //}

            //if (contador == 1)
            //{
            //    var colaborador = new ChamadoOcorrColaboradorViewModel();
            //    //var colaborador = new ChamadoOcorrenciaColaborador();
            //    colaborador.Id = 2921;
            //    colaborador.HoraInicio = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            //    colaborador.HoraFim = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            //    colaborador.TotalHoras = 0;
            //    colaborador.UsuarioId = 5;
            //    colaborador.ChamadoOcorrenciaId = item.Id;

            //    item.ChamadoOcorrenciaColaboradores.Add(colaborador);
            //}

            //Console.WriteLine("id: {0}, Nome: {1} STATUS: {2}", item.Id, item.Data, item.NomeStatus);

            //foreach (var colab in item.ChamadoOcorrenciaColaboradores)
            //{
            //    Console.WriteLine("======= colaboradores =====================");
            //    Console.WriteLine("id: {0}, Nome: {1} Descricao: {2}", colab.Id, colab.HoraInicio, colab.HoraFim);
            //}

            contador++;

            //Console.WriteLine("============================");

            //Console.WriteLine("============================");

            //Console.WriteLine(model.Id + " - " + model.NomeUsuario);
            //foreach (var item in model)
            //{
            //    Console.WriteLine("id: {0}, Nome: {1} Descricao: {2}", item.Id, item.Id, item.NomeStatus);
            //}
            //Console.WriteLine("============================");

            //var lista = app.Filtrar("Par_Id", "");

            Console.WriteLine("Fim ----------------------");
            Console.Read();
        }
    }
}
