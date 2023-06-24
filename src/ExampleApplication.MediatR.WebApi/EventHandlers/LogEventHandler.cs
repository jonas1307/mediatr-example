using ExampleApplication.MediatR.WebApi.Notifications;
using MediatR;

namespace ExampleApplication.MediatR.WebApi.EventHandlers
{
    public class LogEventHandler :
                            INotificationHandler<CreateProductNotification>,
                            INotificationHandler<UpdateProductNotification>,
                            INotificationHandler<DeleteProductNotification>,
                            INotificationHandler<ErrorNotification>
    {
        public Task Handle(CreateProductNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Created: '{notification.Id} " +
                    $"- {notification.Name} - {notification.Price}'");
            }, cancellationToken);
        }

        public Task Handle(UpdateProductNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Updated: '{notification.Id} - {notification.Name} " +
                    $"- {notification.Price} - {notification.IsFinished}'");
            }, cancellationToken);
        }

        public Task Handle(DeleteProductNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Deleted: '{notification.Id} " +
                    $"- {notification.IsFinished}'");
            }, cancellationToken);
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Error: '{notification.ErrorMessage} \n {notification.StackTrace}'");
            }, cancellationToken);
        }
    }
}
