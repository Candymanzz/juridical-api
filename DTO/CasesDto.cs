namespace juridical_api.DTO
{
    public record CasesDto(Guid Id, string CaseName, string Description, DateTime OpeningDate, Guid ClientId, Guid LawyerId);
}
