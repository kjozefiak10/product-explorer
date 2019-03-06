using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProductExplorer.Controllers;
using ProductExplorer.DAL;
using ProductExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExplorer.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private ProductController _productController;


        [TestMethod]
        public async Task GetProducts_EmptyProducts_ReturnOkWithoutBody()
        {
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.GetProducts().Returns(Enumerable.Empty<ProductModel>());
            _productController = new ProductController(productProvider);


            var result = await _productController.GetProducts();


            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should().Be(Enumerable.Empty<ProductModel>());
        }

        [TestMethod]
        public async Task GetProducts_OneProduct_ReturnOkWithBody()
        {
            var products = new List<ProductModel> { new ProductModel(0, "Test", "test", new DateTime(), new DateTime()) };
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.GetProducts().Returns(products);
            _productController = new ProductController(productProvider);


            var result = await _productController.GetProducts();


            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should().Be(products);
        }

        [TestMethod]
        public async Task GetProduct_ProductExist_ReturnOkWithBody()
        {
            var product = new ProductModel(0, "Test", "test", new DateTime(), new DateTime());
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.GetProduct(Arg.Any<int>()).Returns(product);
            _productController = new ProductController(productProvider);


            var result = await _productController.GetProduct(0);


            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should().Be(product);
        }

        [TestMethod]
        public async Task DeleteProduct_ProductExist_ReturnOkWithoutBody()
        {
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.DeleteProduct(Arg.Any<int>()).Returns(Task.CompletedTask);
            _productController = new ProductController(productProvider);


            var result = await _productController.DeleteProduct(0);


            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public async Task UpdateProduct_ProductExist_ReturnNoContentWithoutBody()
        {
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.UpdateProduct(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>()).Returns(Task.CompletedTask);
            _productController = new ProductController(productProvider);


            var result = await _productController.UpdateProduct(0, new UpdateProductModel());


            result.Should().BeOfType<NoContentResult>();
        }

        [TestMethod]
        public async Task AddProduct_ProductExist_ReturnCreaterdWithBody()
        {
            var product = new ProductModel(0, "Test", "test", new DateTime(), new DateTime());
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.AddProduct(Arg.Any<string>(), Arg.Any<string>()).Returns(product);
            _productController = new ProductController(productProvider);


            var result = await _productController.AddProduct(new AddProductModel());


            result.Should().BeOfType<CreatedResult>();
            ((CreatedResult)result).Value.Should().Be(product);
            ((CreatedResult)result).Location.Should().Be("product/0");
        }
    }
}
