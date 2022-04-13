using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]//Padrão para APIs; Recurso no Plural
    public class ProjectsController : ControllerBase//Clicar CTRL . > Enter
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Update at ProjectController";//Mostrar que atualizou
            _option = option.Value;
        }

        [HttpGet]//URL: api/projects?query=net core (url fica assim)
        public IActionResult Get(string query)//Adiciconar uma query
        {
            // * FILTRAR OU BUSCAR TODOS
            return Ok();//Mesmo que enconte 0 elementos padrão retorna OK
        }
        // api/projects/3... ID do projeto
        [HttpGet("{id}")]// Adicionar o parametro ("{id}")
        //Retorno IActionResult > Mudar nome do metodo para GetById > (Parametro)
        public IActionResult GetById(int id)
        {
            // * LOCALIZAR O PROJETO
            // Return NotFound(); Caso não loclaize o projeto
            return Ok();//Retorna OK caso encontre o projeto
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            // Return BadRequest(); (Algum campo esta fora do padrão)
            if (createProject.Title.Length > 50)// Se Titulo tiver mais que 50
            {
                return BadRequest();
            }
            // * CADASTRAR O PROJETO
            // Ou voce coloca o nome para encontrar o objeto cadastrado ("GetById")
            // Ou usa: (nameof(GetById))
            //Usa 3 Parametros:             1 -   2 - Parametro paar URL detalhes3 - Objeto criado
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }
        // api/projects/2
        [HttpPut("{id}")]// Pode receber por URL ou corpo da requisição
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }
            // * ATUALIZO OBJETO
            return NoContent();//Retorno padrão é NoContent
        }
        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // *BUSCAR SE NÃO EXISTIR RETORNAR: NotFound

            return NoContent();//Remover > Pode ser permanente não indicada, ou alterar uma propiredade ativo/inativo
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]//Post indica criação
        public IActionResult PostComments(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }
        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();// NoContend = Sucesso
        }
        // api/projects/1/finish
        [HttpPut("{id}/finish")] // LoginModel
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
