using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class ContractNotFoundException : NotFoundException
    {
        public ContractNotFoundException() : base() { }
        public ContractNotFoundException(string message) : base(message) { }
        public ContractNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
