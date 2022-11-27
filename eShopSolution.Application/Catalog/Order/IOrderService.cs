using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Order
{
    public interface IOrderService
    {
        Task<int> CreateAsync(CheckoutRequest request);
    }
}
