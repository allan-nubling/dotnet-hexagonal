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
            throw new ExampleException(nameof(ExampleUseCase), "Um erro acontece");
        }

        return new ExampleUseCaseOutput() { Bar = input.Foo };
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

