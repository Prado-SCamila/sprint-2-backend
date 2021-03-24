using senai_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_WebApi.Interfaces
{
    /// <summary>
    /// interface responsável pelo repositório de generos
    /// </summary>
    public interface IGeneroRepository
    {
        //Tiporetorno NomeMetodo (TipoParametro parametro)
        //void Cadastrar();

        /// <summary>
        /// Retorna todos os generos
        /// </summary>
        /// <returns></returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um genero através do seu id
        /// </summary>
        /// <returns></returns>
        GeneroDomain BuscarPorId();

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero"></param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um id passando ele através do objeto genero
        /// </summary>
        /// <param name="genero"></param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um id passando ele por uma url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// deleta uma linha de registro intera de um objeto de ujm id x
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
