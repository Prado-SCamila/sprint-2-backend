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
    public class EstudiosController : ControllerBase
    {
        
        private EstudiosRepository _estudiosRepository { get ; set; }

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            List<EstudiosDomain> listaEstudios = _estudiosRepository.ListarTodos();

            return Ok(listaEstudios);
        }
         [HttpPost]
         public IActionResult Post(EstudiosDomain novoEstudio)
         {

            _estudiosRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
         }
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, EstudiosDomain estudioAtualizado)
        {
            _estudiosRepository.AtualizarIdUrl(id, estudioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _estudiosRepository.Deletar();

            //No content
            return StatusCode(204);
        }
    }
}
