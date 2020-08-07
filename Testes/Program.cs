using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<string>();
            var servico = new ClienteServico();
            try
            {
                lista = servico.ImportarXml(@"C:\Projetos\Domper\SIDomperWeb\Banco\11.xml");
                if (lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                //Console.WriteLine("Erro: " + ex.Message);
                //foreach (var item in lista)
                //{
                //    Console.WriteLine(item);
                //}
            }

            Console.WriteLine("Fim ----------------------");
            Console.Read();
        }
    }
}
