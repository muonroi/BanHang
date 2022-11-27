using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Order
{
    public class OrderService : IOrderService
    {
        private readonly EShopDbContext _context;
        private readonly IProductService _productService;
        public OrderService(EShopDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        public async Task<int> CreateAsync(CheckoutRequest request)
        {
            if (request == null)
                return -1;
            var order = new eShopSolution.Data.Entities.Order()
            {
                UserId = request.UserId,
                ShipName = request.Name,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipPhoneNumber = request.PhoneNumber,
                Status = OrderStatus.InProgress
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var item in request.OrderDetails)
            {
                var orderdt = new eShopSolution.Data.Entities.OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = _productService.GetPriceProduct(item.ProductId),
                };
                _context.OrderDetails.Add(orderdt);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
