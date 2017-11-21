namespace AzureSearch.Bll.SearchService
{
    using System.Collections.Generic;

    public interface ISearchServiceClient
    {
        IReadOnlyList<TResult> RunQuery<TResult>(SearchServiceQuery query) where TResult : class;
    }
}
