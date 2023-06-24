using ExampleApplication.MediatR.WebApi.Commands;
using ExampleApplication.MediatR.WebApi.Entities;
using ExampleApplication.MediatR.WebApi.Notifications;
using ExampleApplication.MediatR.WebApi.Repositories;
using MediatR;

namespace ExampleApplication.MediatR.WebApi.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IMediator mediator, IRepository<Product> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price };

            try
            {
                await _repository.Insert(product);
                await _mediator.Publish(new CreateProductNotification { Id = product.Id, Name = product.Name, Price = product.Price }, cancellationToken);

                return await Task.FromResult("Produto criada com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new CreateProductNotification { Id = product.Id, Name = product.Name, Price = product.Price }, cancellationToken);
                await _mediator.Publish(new ErrorNotification { ErrorMessage = ex.Message, StackTrace = ex.StackTrace }, cancellationToken);

                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
