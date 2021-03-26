using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_WebApi.Domains;
using senai_WebApi.Interfaces;
using senai_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller Responsável pelos endpoints URL's referentes ao generos
/// Define a rota de requisição domínio/api/nome do controlador
/// </summary>
/// 

namespace senai_WebApi.Controllers
{

    //indica que a aplicação é no formato json
    [Produces("application/json")]

    //Define a rota na url : ex: localhost:500/api/nome do controlador*
    [Route("api/[controller]")]

    //Define que é um controlador de Api
    [ApiController]
    public class GeneroController : ControllerBase
    {
        //Objeto generoRepository que irá receber todos os métodos definidos na interface IgeneroRepository
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            //instancia um objeto para que haja referencia aos metodos do repositorio
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            return Ok(listaGeneros);
        }

        [HttpGet("{id}")]
        //http://localhost:5000/api/generos/1 (1=id)
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum genero foi encontrado");
            }
            //retorna o status code 200 e a informação contida no generobuscado
            return Ok(generoBuscado);
        }



        [HttpPost]
        //cadastra um novo genero
        ///<summary>
        ///Return status code 201- created.
        ///</summary>
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um genero  existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do genero que será atualizado</param>
        /// <param name="generoAtualizado">objeto com a nova informação</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            //faz a chamada para o método passando os parametros
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                //caso nao seja encontrado, retorna Notfound com uma mensagem personalizada
                return NotFound(new { mensagem = "Genero nao encontrado", erro = true });

                try
                {
                    _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (new
                {
                    mensagem = "Genero não encontrado",
                    erro = true
                }
                );

        }
        /// <summary>
        /// Atualiza um genero existente passano o id pelo corpo da requisiçao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
    [HttpPut]

        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.IdGenero);

            if(generoBuscado !=null)
            {
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch(Exception erro)
                {
                    return BadRequest(erro);
                }
            }
        }

    [HttpDelete]

       public IActionResult Delete(int id)
        {
            //Chama o método deletar.
            _generoRepository.Deletar(id);

            //Retorna o status code 204- no content
            return StatusCode(204);
        }
    }
}
