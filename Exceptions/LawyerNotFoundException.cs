using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class LawyerNotFoundException : NotFoundException
    {
        public LawyerNotFoundException() : base() { }
        public LawyerNotFoundException(string message) : base(message) { }
        public LawyerNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
