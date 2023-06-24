using MediatR;

namespace ExampleApplication.MediatR.WebApi.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
