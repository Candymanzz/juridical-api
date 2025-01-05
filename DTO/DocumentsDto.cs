namespace juridical_api.DTO
{
    public record DocumentsDto(Guid Id, string DocumentName, DateTime CreationDate, string DocumentType, string DocumentText, Guid CaseId);
}
