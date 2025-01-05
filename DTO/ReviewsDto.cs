namespace juridical_api.DTO
{
    public record ReviewsDto(Guid Id, int Rating, string Comment, DateTime Date, Guid ClientId, Guid LawyerId);
}
