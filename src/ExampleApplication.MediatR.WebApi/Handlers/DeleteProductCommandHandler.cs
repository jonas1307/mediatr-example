using ExampleApplication.MediatR.WebApi.Commands;
using ExampleApplication.MediatR.WebApi.Entities;
using ExampleApplication.MediatR.WebApi.Notifications;
using ExampleApplication.MediatR.WebApi.Repositories;
using MediatR;

namespace ExampleApplication.MediatR.WebApi.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IMediator mediator, IRepository<Product> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new DeleteProductNotification { Id = request.Id, IsFinished = true }, cancellationToken);

                return await Task.FromResult("Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new DeleteProductNotification
                {
                    Id = request.Id,
                    IsFinished = false
                }, cancellationToken);

                await _mediator.Publish(new ErrorNotification
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace
                }, cancellationToken);

                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
