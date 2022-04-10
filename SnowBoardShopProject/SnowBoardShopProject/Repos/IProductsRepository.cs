using Microsoft.EntityFrameworkCore;
using SnowBoardShopProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowBoardShopProject.Repos
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int ProductID);
        void Insert(Product product);
        void Update(Product product);
        void Delete(int productID);
        void Save();
    }

    public class ProductsRepo : IDisposable , IProductsRepository
    {
        private SnowBoardShopContext _context;
        public ProductsRepo()
        {
            _context = new SnowBoardShopContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int productID)
        {
            return _context.Products.Find(productID);
        }
        public void Insert(Product product)
        {
            _context.Products.Add(product);
        }
        public void Update(Product product)
        {
            _context.Entry(product).State =
           EntityState.Modified;
            // It's same as 
            //_context.Update(product);

        }
        public void Delete(int productID)
        {
            Product Product =
           _context.Products.Find(productID);
            _context.Products.Remove(Product);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
