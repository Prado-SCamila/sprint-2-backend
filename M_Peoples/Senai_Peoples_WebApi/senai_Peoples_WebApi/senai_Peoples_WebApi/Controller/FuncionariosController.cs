using Microsoft.AspNetCore.Mvc;
using senai_Peoples_WebApi.Domain;
using senai_Peoples_WebApi.Interface;
using senai_Peoples_WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Peoples_WebApi.Controller
{
    //indica que a aplicação é no formato json
    [Produces("application/json")]

    //Define a rota na url : ex: localhost:500/api/nome do controlador*
    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController: ControllerBase
    {
        //Objeto generoRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        private IFuncionariosRepository funcRepository { get; set; }

        public FuncionariosController()
        {
            //instancia um objeto para que haja referencia aos metodos do repositorio
            funcRepository = new FuncionariosRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<FuncionariosDomain> listaFuncionarios = funcRepository.ListarTodos();

            return Ok(listaFuncionarios);
        }

        [HttpGet("{id}")]
        //http://localhost:5000/api/funcionarios/1 (1=id)
        public IActionResult GetById(int id)
        {
            FuncionariosDomain generoBuscado = funcRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum genero foi encontrado");
            }
            //retorna o status code 200 e a informação contida no generobuscado
            return Ok(generoBuscado);
        }

        [HttpPost]
        //cadastra um novo funcionario
        ///<summary>
        ///Return status code 201- created.
        ///</summary>
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {
            funcRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);
        }
        /// <summary>
        /// Atualiza um funcaionario  existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do genero que será atualizado</param>
        /// <param name="funcionarioAtualizado">objeto com a nova informação</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public IActionResult PutUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {
            //faz a chamada para o método passando os parametros
            FuncionariosDomain generoBuscado = funcRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                //caso nao seja encontrado, retorna Notfound com uma mensagem personalizada
                return NotFound(new { mensagem = "Funcionario nao encontrado", erro = true });

                try
                {
                    funcRepository.AtualizarIdUrl(id, funcionarioAtualizado);

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
                    mensagem = "Funcionario não encontrado",
                    erro = true
                }
                );

        }
        /// <summary>
        /// Atualiza um funcionario existente passano o id pelo corpo da requisiçao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult PutIdBody(FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain generoBuscado = funcRepository.BuscarPorId(funcionarioAtualizado.IdFuncionario);

            if (generoBuscado != null)
            {
                try
                {
                    funcRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            //Chama o método deletar.
            funcRepository.Delete(id);

            //Retorna o status code 204- no content
            return StatusCode(204);
        }
    }
}

