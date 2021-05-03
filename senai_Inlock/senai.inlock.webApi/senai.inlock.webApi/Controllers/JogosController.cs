using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
        [ApiController]
    public class JogosController : ControllerBase
    {
        private JogosRepository _jogosRepository { get; set; }
    }
    [HttpGet]
        public IActionResult Get()
        {
        List<JogosDomain> listaJogos = _jogosRepository.ListarTodos();

        return Ok(listaJogos);
        }
     [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {

        _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }
    [HttpPut("{id}")]
    public IActionResult PutUrl(int id, JogosDomain jogoAtualizado)
    {
        _jogosRepository.AtualizarIdUrl(id, jogoAtualizado);

        if(jogoBuscado == null)
        {
            return NotFound
                (new
                {
                    mensagem = "jogo não encontrado",
                     erro = true
                }
                );
        }
        try
        {
            _jogoRepository.AtualizarUrl(id, jogoAtualizado);

            return NoContent();
        }
        catch(Exception erro)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _jogosRepository.Deletar();

        //No content
        return StatusCode(204);
    }
}
