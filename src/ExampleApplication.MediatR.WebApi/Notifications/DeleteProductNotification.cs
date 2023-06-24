using MediatR;

namespace ExampleApplication.MediatR.WebApi.Notifications
{
    public class DeleteProductNotification : INotification
    {
        public Guid Id { get; set; }
        public bool IsFinished { get; set; }
    }
}
