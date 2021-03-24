using senai_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WebApi.Interfaces
{
    public interface IFilmeRepository
    {
        //Tiporetorno NomeMetodo (TipoParametro parametro)
        //void Cadastrar();

        /// <summary>
        /// Retorna todos os titulos de filmes
        /// </summary>
        /// <returns></returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar um filme através do seu id
        /// </summary>
        /// <returns></returns>
       FilmeDomain BuscarPorId();

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoFilme"></param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um id passando ele através do objeto gfilme
        /// </summary>
        /// <param name="filme"></param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um id passando ele por uma url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// deleta uma linha de registro intera de um objeto de ujm id x
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
