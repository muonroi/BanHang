using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;


namespace eShopSolution.WebApp.Models
{
    public class CheckoutViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}