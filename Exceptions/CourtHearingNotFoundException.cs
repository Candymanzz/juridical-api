using juridical_api.Models.Extensions;

namespace juridical_api.Exceptions
{
    public sealed class CourtHearingNotFoundException : NotFoundException
    {
        public CourtHearingNotFoundException() : base() { }
        public CourtHearingNotFoundException(string message) : base(message) { }
        public CourtHearingNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
