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
    }
}
