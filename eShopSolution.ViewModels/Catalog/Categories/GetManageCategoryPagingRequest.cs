using eShopSolution.ViewModels.Common;

namespace eShopSolution.ViewModels.Catalog.Categories
{
    public class GetManageCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }
    }
}