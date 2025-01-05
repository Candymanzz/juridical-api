namespace juridical_api.DTO
{
    public record CourtHearingsDto(Guid Id, DateTime HearingDate, string Place, Guid CaseId);
}
