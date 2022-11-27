using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.Data.Enums;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;

        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CategoryCreateRequest request)
        {
            if (request == null)
                return -1;
            var categoryTranslation = new eShopSolution.Data.Entities.CategoryTranslation()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                SeoAlias = request.SeoAlias,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle,
                LanguageId = request.LanguageId,
            };
            _context.CategoryTranslations.Add(categoryTranslation);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }

        public async Task<PagedResult<CategoryTranslationVM>> GetAllPaging(GetManageCategoryPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Categories
                        join pt in _context.CategoryTranslations on p.Id equals pt.CategoryId
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryTranslationVM()
                {
                    Id = x.pt.Id,
                    CategoryId = x.p.Id,
                    Name = x.pt.Name,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryTranslationVM>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }
    }
}