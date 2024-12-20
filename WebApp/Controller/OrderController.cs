using Dapper;
using Npgsql;
using System.Net;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service):ControllerBase
{
[HttpPost]
public async Task<Response<bool>> Add(Order order)
{
    var res=await service.AddOrder(order);
    return res;
}
[HttpGet]
public async Task<Response<List<Order>>> GetAll()
{
    var res=await service.GetAllOrders();
    return res;
}
[HttpPut("update-status")]
public async Task<Response<bool>> Update(Order order)
{
    var res=await service.UpdateOrder(order);
    return res;
}
[HttpGet("get-by-id")]
public async Task<Response<Order>> GetByCustomer(int id)
{
    var res=await service.GetOrderById(id);
    return res;
}
[HttpDelete]
public async Task<Response<bool>> Delete(int id)
{
    var res=await service.DeleteOrder(id);
    return res;
}
}