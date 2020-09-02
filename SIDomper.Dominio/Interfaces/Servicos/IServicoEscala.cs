using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoEscala
    {
        Escala Novo(int idUsuario);
        Escala Editar(int id, int idUsuario, ref string mensagem);
        Escala ObterPorId(int id);        
        void Relatorio(int idUsuario);
        IEnumerable<Escala> ListarPorData(DateTime data);
        void Excluir(Escala model, int idUsuario);
        void Salvar(Escala model);
        Escala ObterPorData(DateTime data);
        string EnviarSMS();
    }
}
