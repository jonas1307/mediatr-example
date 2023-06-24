using MediatR;

namespace ExampleApplication.MediatR.WebApi.Notifications
{
    public class UpdateProductNotification : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsFinished { get; set; }
    }
}
