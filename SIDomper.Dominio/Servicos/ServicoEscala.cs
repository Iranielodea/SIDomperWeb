﻿using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoEscala : IServicoEscala
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<Escala> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoEscala(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<Escala> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Escala;
        }

        public Escala Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Escala model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioEscala.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<Escala> ListarPorData(DateTime data)
        {
            return _uow.RepositorioEscala.Get(x => x.Data == data);
        }

        public string EnviarSMS()
        {
            //var dataAtual = Convert.ToDateTime("25/02/2020"); // DateTime.Now.Date;
            //var horaAtual = TimeSpan.Parse("01:00");  //TimeSpan.Parse(DateTime.Now.ToShortTimeString());

            var dataAtual = DateTime.Now.Date;
            var horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());

            var escala = _uow.RepositorioEscala.First(x => x.Data == dataAtual 
                && x.HoraInicio <= horaAtual 
                && x.HoraFim >= horaAtual);
            try
            {
                //54999999999 (ddd)numero
                if (escala != null)
                {
                    if (escala.Usuario != null && !string.IsNullOrEmpty(escala.Usuario.Telefone))
                        return Funcoes.Utils.SomenteNumero(escala.Usuario.Telefone);
                    else
                        return "";
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public Escala Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var escala = new Escala();
            return escala;
        }

        public Escala ObterPorData(DateTime data)
        {
            return _uow.RepositorioEscala.First(x => x.Data == data);
        }

        public Escala ObterPorId(int id)
        {
            return _uow.RepositorioEscala.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Escala model)
        {
            if (model.HoraInicio > model.HoraFim)
                throw new Exception("Hora Inicial maior que Hora Final!");
            
            double HoraInicio = Funcoes.Utils.HoraToDecimal(model.HoraInicio.ToString());
            double HoraFim = Funcoes.Utils.HoraToDecimal(model.HoraFim.ToString());
            model.TotalHoras = HoraFim - HoraInicio;

            _uow.RepositorioEscala.Salvar(model);
            _uow.SaveChanges();
        }
    }
}
