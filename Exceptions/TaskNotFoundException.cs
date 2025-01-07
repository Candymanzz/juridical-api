using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class TaskNotFoundException : NotFoundException
    {
        public TaskNotFoundException() : base() { }
        public TaskNotFoundException(string message) : base(message) { }
        public TaskNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
