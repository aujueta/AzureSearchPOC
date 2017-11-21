namespace AzureSearch.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SearchRequest
    {
        [Required]
        public string IndexName { get; set; }

        [Required]
        public string SearchString { get; set; }
        
        public string FilterParameter { get; set; }

        [Required]
        public string[] SelectParameters { get; set; }

        public string[] OrderParameters { get; set; }
    }
}
