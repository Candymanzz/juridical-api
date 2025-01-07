using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException() : base() { }
        public ReviewNotFoundException(string message) : base(message) { }
        public ReviewNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
