namespace juridical_api.DTO
{
    public record TasksDto(Guid Id, string TaskDescription, DateTime DateOfCompletion, string Status, Guid CaseId, Guid LawyerId);
}
