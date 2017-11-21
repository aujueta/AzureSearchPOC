namespace AzureSearch.Bll.SearchService
{
    public class SearchServiceQuery
    {
        public string IndexName { get; set; }

        public string SearchString { get; set; }

        public string FilterParameter { get; set; }

        public string[] SelectParameters { get; set; }

        public string[] OrderParameters { get; set; }
    }
}
