using MediatR;

namespace ExampleApplication.MediatR.WebApi.Notifications
{
    public class ErrorNotification : INotification
    {
        public string ErrorMessage { get; set; }
        public string? StackTrace { get; set; }
    }
}
