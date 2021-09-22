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
            //var product = new Product();
            //var kind = new Kind();
            //var shipper = new Shipper();
            //var productBasket = new ProductBasket();

            //var dbContext = new Mock<DbContextOptions>();
            //var dbSetMock = new Mock<DbSet<Product>>();
            //var dbSetMock1 = new Mock<DbSet<Kind>>();
            //var dbSetMock2= new Mock<DbSet<Shipper>>();
            //var dbSetMock3 = new Mock<DbSet<ProductBasket>>();
            ////dbSetMock.Setup(x => x.)
            //var mockContext = new Mock<ApplicationContext>(dbContext.Object);
            //mockContext.Setup(x => x.Kinds).Returns(dbSetMock1.Object);
            //mockContext.Setup(x => x.Shippers).Returns(dbSetMock2.Object);
            //mockContext.Setup(x => x.Products).Returns(dbSetMock.Object);
            //mockContext.Setup(x => x.Baskets).Returns(dbSetMock3.Object);


            ///////////////////////////////////////////////////////////////////
            
            //dbSetMock.Setup(x => x.Add(It.IsAny<Product>())).Returns(product);
            
            //var repository = new ProductActionsDB(mockContext.Object);

            //repository.Setup(x => x.ReturnAll(It.IsAny<bool>()))
            //    .Returns((int i) => bookInMemoryDatabase.Single(bo => bo.Id == i));
            //var mockSetProducts = new Mock<DbSet<Product>>();

            //mockContext.Setup(m => m.Products).Returns(mockSetProducts.Object);

            //var service = new ProductActionsDB(mockContext.Object);
            //service.CreateProduct(GetProduct().KindId, GetProduct());

            //mockSetProducts.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
