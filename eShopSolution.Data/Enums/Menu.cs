using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Data.Enums
{
    public enum Menu
    {
        [Display(Name = "DƯỠNG DA")]
        Cat1,
        [Display(Name = "MẶT NẠ")]
        Cat2,
        [Display(Name = "TRANG ĐIỂM")]
        Cat3,
        [Display(Name = "CHĂM SÓC TÓC & CƠ THỂ")]
        Cat4,
        [Display(Name = "CHỐNG NẮNG")]
        Cat5,
        [Display(Name = "KHÁC")]
        Cat6,
    }
}
