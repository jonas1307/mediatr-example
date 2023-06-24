using ExampleApplication.MediatR.WebApi.Commands;
using ExampleApplication.MediatR.WebApi.Entities;
using ExampleApplication.MediatR.WebApi.Notifications;
using ExampleApplication.MediatR.WebApi.Repositories;
using MediatR;

namespace ExampleApplication.MediatR.WebApi.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IMediator mediator, IRepository<Product> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };

            try
            {
                await _repository.Update(product);

                await _mediator.Publish(new UpdateProductNotification { Id = product.Id, Name = product.Name, Price = product.Price }, cancellationToken);

                return await Task.FromResult("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new UpdateProductNotification
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                }, cancellationToken);

                await _mediator.Publish(new ErrorNotification
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace
                }, cancellationToken);

                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }
        }
    }
}
