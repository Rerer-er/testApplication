using ActionDB;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ProductActionsDBTest
    {
        public Product GetProduct()
        {
            return new Product()
            {
                ProductId = 77,
                Name = "dsfsdf",
                About = "dsffsd",
                KindId = 1,
            };
        }
        public List<Product> Products(){

            return new List<Product>()
                    {
                        new Product { ProductId =50, Name = "rwer", Price = 3000,},
                        new Product { ProductId =51, Name = "rwer", Price = 3000,},
                        new Product { ProductId =52, Name = "rwer", Price = 3000,},
                        new Product { ProductId =53, Name = "rwer", Price = 3000,}
                    };
        }
        [Fact]
        public void ProductActionsDBTest1()
        {
            var product = new Product();

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<Product>>();
            context.Setup(x => x.Set<Product>()).Returns(dbSetMock.Object);
            //dbSetMock.Setup(x => x.Add(It.IsAny<Product>())).Returns(product);


            var repository = new ProductActionsDB(context.Object);

            //repository.Setup(x => x.ReturnAll(It.IsAny<bool>()))
            //    .Returns((int i) => bookInMemoryDatabase.Single(bo => bo.Id == i));
            //var mockSetProducts = new Mock<DbSet<Product>>();
            //var mockContext = new Mock<ApplicationContext>();

            //mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);

            //var service = new ProductActionsDB(mockContext.Object);
            //service.CreateProduct(GetProduct().KindId, GetProduct());

            //mockSetProducts.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
