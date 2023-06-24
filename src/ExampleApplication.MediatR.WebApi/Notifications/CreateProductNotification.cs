using MediatR;

namespace ExampleApplication.MediatR.WebApi.Notifications
{
    public class CreateProductNotification : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
