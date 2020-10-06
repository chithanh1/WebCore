using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegeFood.Models;
using VegeFood.Models.SQLModels;

namespace VegeFood.Services.SQLServices
{
    public class ProductService: SQLBaseService
    {
        public ProductService(IConfiguration configuration) : base(configuration) { }

        public Result InsertNewProduct(InsertProductInfo newProduct)
        {
            Product checkProduct = SqlData.Products.SingleOrDefault(x => x.Name == newProduct.Name);
            if (checkProduct != null) return new Result
            {
                status = false,
                data = $"The product with name: {newProduct.Name} is exsist"
            };
            Product product = new Product()
            {
                Name = newProduct.Name,
                CategoryId = ProductConfig.category[newProduct.CategoryString],
                Amount = newProduct.Amount,
                Price = newProduct.Price,
                Sale = newProduct.Sale,
                Description = newProduct.Description
            };
            product.Image = "/images/product/product-1.jpg";
            product.Rating = 0;
            product.Sold = 0;
            product.Status = "enable";
            SqlData.Products.Add(product);
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = null
            };
            else return new Result
            {
                status = false,
                data = "Do not insert new product"
            };
        }

        public async Task<Result> InsertNewProductAsync(InsertProductInfo newProduct)
        {
            Product checkProduct = await SqlData.Products.SingleOrDefaultAsync(x => x.Name == newProduct.Name);
            if (checkProduct != null) return new Result
            {
                status = false,
                data = $"The product with name: {newProduct.Name} is exsist"
            };
            Product product = new Product()
            {
                Name = newProduct.Name,
                CategoryId = ProductConfig.category[newProduct.CategoryString],
                Amount = newProduct.Amount,
                Price = newProduct.Price,
                Sale = newProduct.Sale,
                Description = newProduct.Description
            };
            product.Image = "/images/product/product-1.jpg";
            product.Rating = 0;
            product.Sold = 0;
            product.Status = "enable";
            await SqlData.Products.AddAsync(product);
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = null
            };
            else return new Result
            {
                status = false,
                data = "Do not insert new product"
            };
        }

        public Product GetProductById(int productId)
        {
            Product product = SqlData.Products.Find(productId);
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product = await SqlData.Products.FindAsync(productId);
            return product;
        }

        public List<Product> GetListProducts()
        {
            List<Product> productList = SqlData.Products.ToList();
            return productList;
        }

        public async Task<List<Product>> GetListProductsAsync()
        {
            List<Product> productList = await SqlData.Products.ToListAsync();
            return productList;
        }

        public Result UpdateProduct(UpdateProductInfo updateProduct)
        {
            Product product = SqlData.Products.Find(updateProduct.Id);
            if (product == null) return new Result
            {
                status = false,
                data = $"the product with id: {updateProduct.Id} is not exsist"
            };
            if(updateProduct.Name != null)
            {
                Product checkProduct = SqlData.Products.SingleOrDefault(x => x.Name == updateProduct.Name);
                if (checkProduct != null) return new Result
                {
                    status = false,
                    data = $"the product with name: {updateProduct.Name} is exsist"
                };
                product.Name = updateProduct.Name;
            }
            if (updateProduct.Image != null) product.Image = updateProduct.Image;
            if (updateProduct.Amount > 0) product.Amount = updateProduct.Amount;
            if (updateProduct.Price > 0) product.Price = updateProduct.Price;
            if (updateProduct.Sale > 0) product.Sale = updateProduct.Sale;
            if (updateProduct.Description != null) product.Description = updateProduct.Description;
            if (updateProduct.Status != null) product.Status = updateProduct.Status;
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = product
            };
            else return new Result
            {
                status = false,
                data = $"Do not update product with id: {updateProduct.Id}"
            };
        }

        public async Task<Result> UpdateProductAsync(UpdateProductInfo updateProduct)
        {
            Product product = await SqlData.Products.FindAsync(updateProduct.Id);
            if (product == null) return new Result
            {
                status = false,
                data = $"the product with id: {updateProduct.Id} is not exsist"
            };
            if (updateProduct.Name != null)
            {
                Product checkProduct = await SqlData.Products.SingleOrDefaultAsync(x => x.Name == updateProduct.Name);
                if (checkProduct != null) return new Result
                {
                    status = false,
                    data = $"the product with name: {updateProduct.Name} is exsist"
                };
                product.Name = updateProduct.Name;
            }
            if (updateProduct.Image != null) product.Image = updateProduct.Image;
            if (updateProduct.Amount > 0) product.Amount = updateProduct.Amount;
            if (updateProduct.Price > 0) product.Price = updateProduct.Price;
            if (updateProduct.Sale > 0) product.Sale = updateProduct.Sale;
            if (updateProduct.Description != null) product.Description = updateProduct.Description;
            if (updateProduct.Status != null) product.Status = updateProduct.Status;
            int check = await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = product
            };
            else return new Result
            {
                status = false,
                data = $"Do not update product with id: {updateProduct.Id}"
            };
        }

        public Result DeleteProduct(int productId)
        {
            Product product = SqlData.Products.Find(productId);
            if (product == null) return new Result
            {
                status = false,
                data = null,
            };
            SqlData.Remove(product);
            int check = SqlData.SaveChanges();
            if (check > 0) return new Result
            {
                status = true,
                data = product,
            };
            else return new Result
            {
                status = false,
                data = $"Do not delete product with id: {productId}"
            };
        }

        public async Task<Result> DeleteProductAsync(int productId)
        {
            Product product = await SqlData.Products.FindAsync(productId);
            if (product == null) return new Result
            {
                status = false,
                data = null,
            };
            SqlData.Remove(product);
            int check =  await SqlData.SaveChangesAsync();
            if (check > 0) return new Result
            {
                status = true,
                data = product,
            };
            else return new Result
            {
                status = false,
                data = $"Do not delete product with id: {productId}"
            };
        }
    }
}
