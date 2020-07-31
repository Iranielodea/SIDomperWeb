﻿using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        string EmailsDoCliente(Cliente cliente);
        Cliente ObterPorDocumento(string documento);
    }
}
