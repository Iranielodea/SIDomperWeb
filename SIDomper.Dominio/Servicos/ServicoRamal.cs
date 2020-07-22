using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoRamal : IServicoRamal
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<RamalConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoRamal(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<RamalConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Ramal;
        }

        public Ramal Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Ramal model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioRamal.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<RamalConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Ram_Id as Id,");
            sb.AppendLine(" Ram_Departamento as Departamento");
            sb.AppendLine(" FROM Ramal");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Ram_Id > 0");
            }

            sb.AppendLine(" ORDER BY " + campo);
            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Ramal Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var ramal = new Ramal();
            return ramal;
        }

        public Ramal ObterPorId(int id)
        {
            return _uow.RepositorioRamal.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Ramal model)
        {
            _uow.RepositorioRamal.Salvar(model);

            if (model.Id == 0)
                _uow.RepositorioRamal.Salvar(model);
            else
            {
                var ramal = _uow.RepositorioRamal.find(model.Id);
                if (ramal == null)
                    ramal = new Ramal();

                AlterarItem(ramal, model);
                ExcluirItem(ramal, model);

                ramal.Departamento = model.Departamento;
                _uow.RepositorioRamal.Salvar(ramal);
            }
            _uow.SaveChanges();
        }

        private void AlterarItem(Ramal ramal, Ramal model)
        {
            foreach (var item in model.RamalItens)
            {
                if (item.Numero <= 0 || string.IsNullOrWhiteSpace(item.Nome))
                    throw new Exception("Informe o ramal e o nome!");

                if (item.Id == 0)
                    ramal.RamalItens.Add(item);
                else
                {
                    var temp = ramal.RamalItens.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Nome = item.Nome;
                        temp.Numero = item.Numero;
                    }
                }
            }
        }

        private void ExcluirItem(Ramal ramalBanco, Ramal model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in ramalBanco.RamalItens)
            {
                var dados = model.RamalItens.FirstOrDefault(x => x.Id == itemBanco.Id);
                if (dados == null)
                {
                    if (itemBanco.Id > 0)
                    {
                        if (i == 1)
                            idDelecao += itemBanco.Id;
                        else
                            idDelecao += "," + itemBanco.Id;
                        i++;
                    }
                }
            }

            if (idDelecao != "")
                _uow.Executar("DELETE FROM Ramal_Itens WHERE RamIt_Id in (" + idDelecao + ")");
        }
    }
}
