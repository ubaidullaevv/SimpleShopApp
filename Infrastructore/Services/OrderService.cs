using Dapper;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using System.Net;
namespace Services;


public class OrderService(DapperContext _context) : IOrderService
{
    public async  Task<Response<bool>> AddOrder(Order order)
    {
        using var context=_context.Connection();
        string cmd="insert into Orders(productid,quantity,totalprice,orderdate)values(@ProductId,@Quantity,@TotalPrice,@OrderDate)";
        var res=await context.ExecuteAsync(cmd,order);
        if(order==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteOrder(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Orders where Orderid=@OrderId";
        var res=await context.ExecuteAsync(cmd,new {OrderId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public async Task<Response<Order>> GetOrderById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Orders where Orderid=@OrderId";
        var res=await context.QueryFirstOrDefaultAsync<Order>(cmd,new {OrderId=id});
        if(res==null)
        {
            return new Response<Order>(HttpStatusCode.NotFound,"Cannot found Order!");
        }
        return new Response<Order>(res);
    }

    public async Task<Response<List<Order>>> GetAllOrders()
    {
        using var context=_context.Connection();
        string cmd="select * from Orders";
        var res=(await context.QueryAsync<Order>(cmd)).ToList();
        if(res==null)
        {
            return new Response<List<Order>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Order>>(res);
    }

    public async Task<Response<bool>> UpdateOrder(Order order)
    {
        using var context=_context.Connection();
        string cmd="update  Orders set orderid=@OrderId, productid=@ProductId,quantity=@Quantity,totalprice=@TotalPrice,orderdate=@OrderDate where Orderid=@OrderId";
        var res=await context.ExecuteAsync(cmd,order);
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

  
    
}
