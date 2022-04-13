namespace DevFreela.API.Models
{
    public class CreateProjectModel//Para receber dados de cadastro de projetos
    {
        public int Id { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
