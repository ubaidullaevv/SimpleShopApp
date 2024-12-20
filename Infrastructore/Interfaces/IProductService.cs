using Domain.DOT;
using Domain.Models;
using Infrastructore.ApiResponse;

namespace Infrastructore.Interfaces;

public interface IProductService
{
   public Task<Response<List<Product>>> GetAllProducts();
   public Task<Response<bool>> AddProduct(Product product); 
   public Task<Response<bool>> UpdateProduct(Product product); 
   public Task<Response<bool>> DeleteProduct(int id); 
   public Task<Response<Product>> GetProductById(int id); 
   public Task<Response<List<GetLowStock>>> GetLowStockProducts();
   public Task<Response<List<GetMostExepensive>>> GetMostExepensiveProducts();
}

