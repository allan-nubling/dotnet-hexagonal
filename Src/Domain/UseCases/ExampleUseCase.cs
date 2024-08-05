using System.Globalization;
using System.Reflection;
using System.Resources;
using Domain.Enums;
using Domain.Exceptions;
namespace Domain.UseCases;
public class ExampleUseCase
{
    /// <summary>A Example Use Case Summary</summary>
    /// <param name="input">O Param de entrada</param>
    /// <returns>A sample Return</returns>
    /// <exception cref="ExampleException">Erro quando acontece uma exceção</exception>
    public async Task<ExampleUseCaseOutput> Execute(ExampleUseCaseInput input)
    {
        await Task.CompletedTask;
        if (input.ShouldThrowAnError == true)
        {
            throw new ExampleException(nameof(ExampleUseCase), ExceptionCode.CE000);
            // throw new Exception("Unexpected test!");
        }
        var resourceManager = new ResourceManager("Domain.Resources.Localization.UseCasesMessages", Assembly.GetExecutingAssembly());
        return new ExampleUseCaseOutput() { Bar = resourceManager.GetString("ExampleUseCaseSuccess") ?? "" };
    }

}

public class ExampleUseCaseInput
{
    public required string Foo { get; set; }
    public bool? ShouldThrowAnError { get; set; }
}

public class ExampleUseCaseOutput
{
    public required string Bar { get; set; }
}

