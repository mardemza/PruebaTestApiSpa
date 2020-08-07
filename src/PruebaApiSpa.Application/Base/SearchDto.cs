namespace PruebaApiSpa.Base
{
    public class SearchDto
    {
        public string Search { get; set; }
        public int Page { get; set; } = 1;
        public string Order { get; set; } = "desc";
        public int PageSize { get; set; } = 10;
        public string OrderColumn { get; set; } = "Id";
    }
}
