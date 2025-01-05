namespace juridical_api.DTO
{
    public record PaymentsDto(Guid Id, DateTime PaymentDate, decimal Amount, string PaymentMethod, Guid ClientId, Guid CaseId);
}
