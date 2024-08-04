using Domain.UseCases;
namespace Tests.Domain.UseCases;
public class ExampleUseCaseTest
{
    readonly ExampleUseCase _sut;
    public ExampleUseCaseTest()
    {
        _sut = new ExampleUseCase();
    }

    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }
}