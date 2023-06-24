using MediatR;

namespace ExampleApplication.MediatR.WebApi.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
