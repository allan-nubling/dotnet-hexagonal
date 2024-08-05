namespace Application.API.v1.Controllers
{
    public class ExampleQueryRequest

    {
        /// <summary>
        /// Indica o nome do template.
        /// </summary>
        /// <example>true</example>
        public bool ThrowError { get; set; }

        /// <summary>
        /// Indica o nome do template.
        /// </summary>
        /// <example>Jeremias</example>
        public string Name { get; set; }
    }
}