using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class ClientNotFoundException : NotFoundException
    {
        public ClientNotFoundException() : base() { }
        public ClientNotFoundException(string message) : base(message) { }
        public ClientNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
