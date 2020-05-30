using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class ClienteEspecificacaoServico
    {
        private readonly ClienteEspecifiacaoEF _rep;

        public ClienteEspecificacaoServico()
        {
            _rep = new ClienteEspecifiacaoEF();
        }

        public ClienteEspecifiacao Novo(int idUsuario)
        {
            // Novo via API
            var model = new ClienteEspecifiacao();
            model.Item = _rep.ProximoNumero();
            model.Data = DateTime.Now.Date;
            return model;
        }

        public ClienteEspecifiacao ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<ClienteEspecifiacaoConsulta> Filtrar(int idCliente)
        {
            return _rep.Filtrar(idCliente);
        }

        public void Excluir(ClienteEspecifiacao model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(ClienteEspecifiacao model)
        {
            if (model.UsuarioId == 0)
                throw new Exception("Informe o usuário!");
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o nome!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a descrição!");

            _rep.Salvar(model);
            _rep.Commit();
        }
    }
}
