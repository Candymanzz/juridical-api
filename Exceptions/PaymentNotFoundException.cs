using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException() : base() { }
        public PaymentNotFoundException(string message) : base(message) { }
        public PaymentNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
