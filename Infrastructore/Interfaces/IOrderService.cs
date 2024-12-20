using Domain.Models;
using Infrastructore.ApiResponse;

namespace Infrastructore.Interfaces;

public interface IOrderService
{
   public Task<Response<List<Order>>> GetAllOrders();
   public Task<Response<bool>> AddOrder(Order order); 
   public Task<Response<bool>> UpdateOrder(Order order); 
   public Task<Response<bool>> DeleteOrder(int id); 
   public Task<Response<Order>> GetOrderById(int id); 
}

