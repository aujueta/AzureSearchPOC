namespace AzureSearch.Bll.SearchService
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Extensions.Configuration;

    public class AzureSearchClient : ISearchServiceClient
    {
        private readonly SearchServiceClient _serviceClient;

        public AzureSearchClient(IConfiguration configuration)
        {
            var searchServiceName = "sureal-dev";
            var apiKey = "yourApiKey";
            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
        }

        public IReadOnlyList<TResult> RunQuery<TResult>(SearchServiceQuery query) where TResult : class
        {
            var indexClient = _serviceClient.Indexes.GetClient(query.IndexName);

            var parameters = new SearchParameters
            {
                OrderBy = query.OrderParameters,
                Filter = query.FilterParameter,
                Select = query.SelectParameters
            };

            var documentSearchResult = indexClient.Documents.Search<TResult>(query.SearchString, parameters);

            return documentSearchResult.Results.Select(searchResult => searchResult.Document).ToList();
        }
    }
}
