using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModel;

namespace VegeFood.Services.SQLService
{
    public class CategoryService: SQLBaseService
    {
        public CategoryService(IConfiguration configuration) : base(configuration) { }

        public Result InsertCategory(Category newCategory)
        {
            Category checkCategory = SqlData.Categories.SingleOrDefault(x => x.Type == newCategory.Type);
            if (checkCategory != null) return new Result
            {
                status = false,
                data = $"the type: {newCategory.Type} is exsist"
            };
            SqlData.Categories.Add(newCategory);
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = newCategory
            };
            return new Result
            {
                status = false,
                data = "do not add new category"
            };
        }

        public async Task<Result> InsertCategoryAsync(Category newCategory)
        {
            Category checkCategory = await SqlData.Categories.SingleOrDefaultAsync(x => x.Type == newCategory.Type);
            if (checkCategory != null) return new Result
            {
                status = false,
                data = $"the type: {newCategory.Type} is exsist"
            };
            await SqlData.Categories.AddAsync(newCategory);
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = newCategory
            };
            return new Result
            {
                status = false,
                data = "do not add new category"
            };
        }

        public Category GetCategoryById(int categoryId)
        {
            Category category = SqlData.Categories.Find(categoryId);
            return category;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            Category category = await SqlData.Categories.FindAsync(categoryId);
            return category;
        }

        public List<Category> GetListCategories()
        {
            List<Category> categorieList = SqlData.Categories.ToList();
            return categorieList;
        }

        public async Task<List<Category>> GetListCategoriesAsync()
        {
            List<Category> categorieList = await SqlData.Categories.ToListAsync();
            return categorieList;
        }

        public Result UpdateCategory(UpdateCategoryInfo updateCategory)
        {
            Category category = SqlData.Categories.Find(updateCategory.Id);
            if (category == null) return new Result
            {
                status = false,
                data = $"the category with id: {updateCategory.Id} do not exist"
            };
            if (updateCategory.Type != null) category.Type = updateCategory.Type;
            if (updateCategory.Description != null) category.Description = updateCategory.Description;
            if (updateCategory.Node != null) category.Node = updateCategory.Node;
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = category
            };
            return new Result
            {
                status = false,
                data = "do not update category"
            };
        }

        public async Task<Result> UpdateCategoryAsync(UpdateCategoryInfo updateCategory)
        {
            Category category = await SqlData.Categories.FindAsync(updateCategory.Id);
            if (category == null) return new Result
            {
                status = false,
                data = $"the category with id: {updateCategory.Id} do not exist"
            };
            if (updateCategory.Type != null) category.Type = updateCategory.Type;
            if (updateCategory.Description != null) category.Description = updateCategory.Description;
            if (updateCategory.Node != null) category.Node = updateCategory.Node;
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = category
            };
            return new Result
            {
                status = false,
                data = "do not update category"
            };
        }
    }
}
