using APICadCenter.Data;
using APICadCenter.Dominio;
using APICadCenter.Repositories;
using APICadCenter.Servico.DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace APICadCenter.Servico
{
    public interface IEnderecoService
    {
        long Criar(EnderecoCriarDTO endereco);
        List<EnderecoDTO> Buscar(int pagina = 1, int tamanhoPaina = 10);
        EnderecoDTO BuscarPorId(int id);
        List<EnderecoDTO> BuscarPorPessoa(int idPessoa, int pagina = 1, int tamanhoPaina = 10);
        void Apagar(long id);
        void Inativar(long id);
        void Ativar(long id);
    }
    public class EnderecoServico : IEnderecoService
    {
        private readonly IEnderecoRepository _repositorio;
        private readonly IValidator<Endereco> _validator;

        public EnderecoServico(IEnderecoRepository repositorio, IValidator<Endereco> validator)
        {
            _repositorio = repositorio;
            _validator = validator;
        }

        public long Criar(EnderecoCriarDTO endereco)
        {
            Endereco enderecoModel = new Endereco(endereco.logradouro, endereco.numero, endereco.municipio, endereco.estadoFederacao, endereco.cep, TipoEndereco.Principal, endereco.pessoaId);
            enderecoModel.SetComplemento(endereco.complemento);

            var validationResult = _validator.Validate(enderecoModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return _repositorio.Creat(enderecoModel);             

        }

        public List<EnderecoDTO> Buscar(int pagina = 1, int tamanhoPaina = 10)
        {
            var retorno = _repositorio.Get(pagina, tamanhoPaina);

            List<EnderecoDTO> enderecoDTOs = new List<EnderecoDTO>();

            if (retorno == null)
                return enderecoDTOs;

            foreach (var endereco in retorno)
            {
                EnderecoDTO end = new EnderecoDTO
                {
                    id = endereco.id,
                    ativo = endereco.Ativo == true ? "Sim" : "Não",
                    logradouro = endereco.Logradouro,
                    numero = endereco.Numero,
                    municipio = endereco.Municipio,
                    estadoFederacao = endereco.Uf,
                    complemento = endereco.Complemento,
                    pais = endereco.Pais,
                    cep = endereco.CodigoPostal,
                    tipoEndereco = endereco.TipoEndereco,
                    contatoId = endereco.PessoaId
                };
                enderecoDTOs.Add(end);
            }

            return enderecoDTOs;
        }

        public EnderecoDTO BuscarPorId(int id)
        {
            var retorno = _repositorio.Get(id);
            EnderecoDTO enderecoDTO = new EnderecoDTO();

            if (retorno == null)
                return enderecoDTO;

            EnderecoDTO endereco = new EnderecoDTO
            {
                id = retorno.id,
                ativo = retorno.Ativo == true ? "Sim" : "Não",
                logradouro = retorno.Logradouro,
                numero = retorno.Numero,
                municipio = retorno.Municipio,
                estadoFederacao = retorno.Uf,
                complemento = retorno.Complemento,
                pais = retorno.Pais,
                cep = retorno.CodigoPostal,
                tipoEndereco = retorno.TipoEndereco,
                contatoId = retorno.PessoaId
            };

            return endereco;
        }

        public List<EnderecoDTO> BuscarPorPessoa(int idPessoa, int pagina = 1, int tamanhoPaina = 10)
        {
            var retorno = _repositorio.GetByPessoa(idPessoa);

            List<EnderecoDTO> enderecoDTOs = new List<EnderecoDTO>();

            if (retorno == null)
                return enderecoDTOs;

            foreach (var endereco in retorno)
            {
                EnderecoDTO end = new EnderecoDTO
                {
                    id = endereco.id,
                    ativo = endereco.Ativo == true ? "Sim" : "Não",
                    logradouro = endereco.Logradouro,
                    numero = endereco.Numero,
                    municipio = endereco.Municipio,
                    estadoFederacao = endereco.Uf,
                    complemento = endereco.Complemento,
                    pais = endereco.Pais,
                    cep = endereco.CodigoPostal,
                    tipoEndereco = endereco.TipoEndereco,
                    contatoId = endereco.PessoaId
                };
                enderecoDTOs.Add(end);
            }
            return enderecoDTOs;
        }

        public void Apagar(long id)
        {
            _repositorio.Delete(id);
        }

        public void Ativar(long id)
        {
            var endereco = _repositorio.Get(id);

            if (endereco is null)
                return;

            endereco.AtivarEndereco();

            _repositorio.Update(endereco);

        }

        public void Inativar(long id)
        {
            var endereco = _repositorio.Get(id);

            if (endereco is null)
                return;

            endereco.InativarEndereco();

            _repositorio.Update(endereco);
        }
    }
}
