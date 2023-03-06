namespace Core.Shared
{
    public record PagedResponse<T>(List<T> list, PageInformation pageInformation) where T : class;

    public record PageInformation(int PageCount, int TotalItemCount, int PageNumber, int pageSize);
}
