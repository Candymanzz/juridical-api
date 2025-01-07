using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class DocumentNotFoundException : NotFoundException
    {
        public DocumentNotFoundException() : base() { }
        public DocumentNotFoundException(string message) : base(message) { }
        public DocumentNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
