namespace AzureSearch.Api.Controllers
{
    using System.Collections.Generic;
    using Bll;
    using Bll.SearchService;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchServiceClient _searchServiceClient;

        public SearchController(ISearchServiceClient searchServiceClient)
        {
            _searchServiceClient = searchServiceClient;
        }

        [HttpPost]
        public IReadOnlyList<UserSearchResult> Search([FromBody] SearchRequest request)
        {
            IReadOnlyList<UserSearchResult> resultList = null;
            if (request != null && ModelState.IsValid)
            {
                SearchServiceQuery query = new SearchServiceQuery
                {
                    IndexName = request.IndexName,
                    SearchString = request.SearchString,
                    FilterParameter = request.FilterParameter,
                    SelectParameters = request.SelectParameters,
                    OrderParameters = request.OrderParameters
                };

                resultList = _searchServiceClient.RunQuery<UserSearchResult>(query);
            }

            return resultList;
        }
    }
}
