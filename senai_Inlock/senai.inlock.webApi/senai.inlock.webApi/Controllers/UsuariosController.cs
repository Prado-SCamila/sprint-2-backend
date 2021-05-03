using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    //Define uma rota de requisição será no formato domínio/api/nomeController
    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UsuariosDomain> listaUsuarios = _usuariosRepository.ListarTodos();
            return Ok(listaUsuarios);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            UsuariosDomain usuarioBuscado = _usuariosRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum Usuario foi encontrado!");
            }
            return Ok(usuarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(UsuariosDomain novoUsuario)
        {

            _usuariosRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, UsuariosDomain usuarioAtualizado)
        {
            _usuariosRepository.AtualizarIdUrl(id, usuarioAtualizado);

            return StatusCode(204);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar();

            //No content
            return StatusCode(204);
        }
    }
}
