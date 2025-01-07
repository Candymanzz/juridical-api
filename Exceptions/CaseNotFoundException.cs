using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class CaseNotFoundException : NotFoundException
    {
        public CaseNotFoundException() : base() { }
        public CaseNotFoundException(string message) : base(message) { }
        public CaseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
