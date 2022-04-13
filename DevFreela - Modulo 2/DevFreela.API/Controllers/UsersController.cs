using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]//Adiocionar reference MVC
    //Padrão Users no plural
    public class UsersController : ControllerBase//Dar acesso as respostas Http
    {
        public UsersController(ExampleClass exampleclass)
        {

        }
        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        // api/users
        [HttpPost]
        //Criar Classe Create... na pasta Models get/set (Username e Password)
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }
        //Ir ProjectsController criar Comentarios usuarios
        // api/projects/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
