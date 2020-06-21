using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class CidadeServico
    {
        private readonly CidadeEF _rep;
        private readonly UsuarioServico _repUsuario;
        private readonly EnProgramas _tipoPrograma;

        public CidadeServico()
        {
            _rep = new CidadeEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Cidade;
        }

        public Cidade Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Cidade
            {
                Ativo = true,
                Codigo = _rep.ProximoCodigo()
            };

            return model;
        }

        public Cidade Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);

            //bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            //if (!permissao)
            //    throw new Exception("Usuário sem Permissão!");

            //return _rep.ObterPorId(id);
        }

        public Cidade ObterPorId(int id)
        {
            return _rep.CidadeRepositorio.find(id);
        }

        public Cidade ObterPorCodigo(int codigo)
        {
            var model = _rep.CidadeRepositorio.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Cidade não Cadastrada!");
            if (model.Ativo == false)
                throw new Exception("Registro Inativo!");

            return model;
        }

        public List<Cidade> Listar(string nome)
        {
            return _rep.Listar(nome).ToList();
        }

        public void Excluir(Cidade model, int idUsuario)
        {
            bool permissao = ListasEstaticasServico.Permissoes(idUsuario, EnProgramas.Cidade, EnTipoManutencao.Excluir);
            if (!permissao)
            {
                throw new Exception("Usuário sem permissão!");
            }

            _rep.CidadeRepositorio.Deletar(model);
            _rep.CidadeRepositorio.Commit();
        }

        public void Excluir(int idUsuario, int id)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Excluir(int idUsuario, Cidade model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Salvar(Cidade model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome");
            if (model.Codigo <= 0)
                throw new Exception("Informe o código");

            if (model.Id > 0)
                _rep.CidadeRepositorio.Update(model);
            else
                _rep.CidadeRepositorio.Add(model);

            _rep.CidadeRepositorio.Commit();
        }

        public void Imprimir(int idUsuario)
        {
            bool permissao = ListasEstaticasServico.Permissoes(idUsuario, EnProgramas.Cidade, EnTipoManutencao.Imprimir);
            if (!permissao)
            {
                throw new Exception("Usuário sem permissão!");
            }
        }

        public List<CidadeConsulta> Filtrar(string campo, string texto, bool? ativo=true, bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem).ToList();
        }
    }
}
