using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<PagedResult<OrderDetailVm>> GetPagings(CheckoutRequest request);

        Task<int> CreateOrder(CheckoutRequest request);
    }
}