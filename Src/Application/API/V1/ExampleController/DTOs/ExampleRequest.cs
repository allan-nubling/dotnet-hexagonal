using System.ComponentModel.DataAnnotations;

namespace Application.API.v1.Controllers
{
    public class ExampleRequest 

    {
        [Required(ErrorMessage = "'TestString' é obrigatório.")]
        public string TestString { get; set; }
    }
}