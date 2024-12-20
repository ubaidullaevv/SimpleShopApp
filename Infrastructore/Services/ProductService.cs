using Dapper;
using Domain.DOT;
using Domain.Models;
using Infrastructore.ApiResponse;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using System.Net;
namespace Services;


public class ProductService(DapperContext _context) : IProductService
{
    public async  Task<Response<bool>> AddProduct(Product Product)
    {
        using var context=_context.Connection();
        string cmd="insert into Products(name,price,stock)values(@Name,@Price,@Stock)";
        var res=await context.ExecuteAsync(cmd,Product);
        if(Product==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteProduct(int id)
    {
         using var context=_context.Connection();
        string cmd="delete from Products where Productid=@ProductId";
        var res=await context.ExecuteAsync(cmd,new {ProductId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
        using var context=_context.Connection();
         string cmd="select * from Products where Productid=@ProductId";
        var res=await context.QueryFirstOrDefaultAsync<Product>(cmd,new {ProductId=id});
        if(res==null)
        {
            return new Response<Product>(HttpStatusCode.NotFound,"Cannot found product!");
        }
        return new Response<Product>(res);
    }

    public async Task<Response<List<Product>>> GetAllProducts()
    {
        using var context=_context.Connection();
        string cmd="select * from Products";
        var res=(await context.QueryAsync<Product>(cmd)).ToList();
        if(res==null)
        {
            return new Response<List<Product>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Product>>(res);
    }

    public async Task<Response<bool>> UpdateProduct(Product Product)
    {
        using var context=_context.Connection();
        string cmd="update  Products set Productid=@ProductId, name=@Name,price=@Price,stock=@Stock where productid=@ProductId";
        var res=await context.ExecuteAsync(cmd,Product);
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        }
        return new Response<bool>(res>0);
    }

    public async Task<Response<List<GetLowStock>>> GetLowStockProducts()
    {
       using var context=_context.Connection();
        string cmd="select * from Products order stock by limit 5";
        var res=(await context.QueryAsync<GetLowStock>(cmd)).ToList();
        if(res==null)
        {
            return new Response<List<GetLowStock>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<GetLowStock>>(res);  
    }

    public async Task<Response<List<GetMostExepensive>>> GetMostExepensiveProducts()
    {
        using var context=_context.Connection();
        string cmd="select * from Products order by price desc limit 1";
        var res=(await context.QueryAsync<GetMostExepensive>(cmd)).ToList();
        if(res==null)
        {
            return new Response<List<GetMostExepensive>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<GetMostExepensive>>(res);
    }
}
