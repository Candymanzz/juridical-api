namespace juridical_api.DTO
{
    public record ContractsDto(Guid Id, DateTime SigningDate, DateTime ExpirationDate, Guid ClientId, Guid LawyerId);
}
