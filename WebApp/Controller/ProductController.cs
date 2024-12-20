using Dapper;
using Npgsql;
using System.Net;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DOT;
namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service):ControllerBase
{
[HttpPost]
public async Task<Response<bool>> Add(Product product)
{
    var res=await service.AddProduct(product);
    return res;
}
[HttpGet]
public async Task<Response<List<Product>>> GetAll()
{
    var res=await service.GetAllProducts();
    return res;
}
[HttpPut("update-status")]
public async Task<Response<bool>> Update(Product product)
{
    var res=await service.UpdateProduct(product);
    return res;
}
[HttpGet("get-by-id")]
public async Task<Response<Product>> GetByCustomer(int id)
{
    var res=await service.GetProductById(id);
    return res;
}
[HttpDelete]
public async Task<Response<bool>> Delete(int id)
{
    var res=await service.DeleteProduct(id);
    return res;
}
[HttpGet("low-stock")]
public async Task<Response<List<GetLowStock>>> GetLowStock()
{
    var res=await service.GetLowStockProducts();
    return res;
}
[HttpGet]
public async Task<Response<List<GetMostExepensive>>> GetMostExepensive()
{
    var res=await service.GetMostExepensiveProducts();
   return res;
}
}