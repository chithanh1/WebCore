using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using VegeFood.Models.SQLServer;

namespace VegeFood.Services
{
    public class ProductService: SQLBaseService
    {
        public ProductService(IConfiguration configuration) : base(configuration) { }

        public Product GetProductById(int productId)
        {
            Product product = SqlData.Products.Find(productId);
            return product;
        }

        public List<Product> GetListProducts()
        {
            List<Product> productList = SqlData.Products.ToList();
            return productList;
        }

        public Product UpdateProduct(UpdateProductInfo updateProduct)
        {
            Product product = SqlData.Products.Find(updateProduct.Id);
            if (product == null) return null;
            if(updateProduct.Name != null)
            {
                Product checkProduct = SqlData.Products.SingleOrDefault(x => x.Name == updateProduct.Name);
                if (checkProduct != null) return null;
                product.Name = updateProduct.Name;
            }
            if (updateProduct.Image != null) product.Image = updateProduct.Image;
            if (updateProduct.Amount > 0) product.Amount = updateProduct.Amount;
            if (updateProduct.Price > 0) product.Price = updateProduct.Price;
            if (updateProduct.Sale > 0) product.Sale = updateProduct.Sale;
            if (updateProduct.Description != null) product.Description = updateProduct.Description;
            if (updateProduct.Status != null) product.Status = updateProduct.Status;
            SqlData.SaveChanges();
            return product;
        }
    }
}
