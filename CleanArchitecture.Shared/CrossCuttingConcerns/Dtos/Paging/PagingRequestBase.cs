namespace CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Paging
{
    public class PagingRequestBase
    {
        public int? PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string? SearchBy { get; set; }
        public string? TextSearch { get; set; }
        public string? OrderCol { get; set; }
        public string? OrderDir { get; set; }
        public int? LanguageId { get; set; }
    }
}
