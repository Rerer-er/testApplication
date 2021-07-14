using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionDB.Extensions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> FilterProduct(this IQueryable<Product> product,
            decimal minPrice, decimal maxPrice) =>
            product.Where(e => (e.Price >= minPrice && e.Price <= maxPrice));
        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
