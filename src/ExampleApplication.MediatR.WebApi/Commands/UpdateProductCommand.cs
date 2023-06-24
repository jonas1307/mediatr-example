using MediatR;

namespace ExampleApplication.MediatR.WebApi.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
