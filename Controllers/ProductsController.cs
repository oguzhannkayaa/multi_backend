using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiBackend.Business;
using MultiBackend.Dtos;
using MultiBackend.Entities;

namespace MultiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.OrderByDescending(c => c.Score).Take(10).ToListAsync();

            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductStoreDto>>> GetProductsByCategoryId(int id)
        {
            var products =  from pro in  _context.Products.Where(c => c.CategoryId == id)
                            join store in _context.Stores on pro.StoreId equals store.Id
                            orderby pro.Score descending
                            select new
                            {
                                ProductName = pro.Name,
                                ProductId = pro.Id,
                                ProductPrice = pro.Price,   
                                ProductStock = pro.Stock,
                                PorductScore = pro.Score,
                                StoreName = store.StoreName,
                                StoreId = store.Id,
                                StoreLink = store.Links,
                                StoreLogo = store.Logo
                            };


            if (products.Any())
            {
                return Ok(products);

            }
            return BadRequest("Now found Product");
        }

    }
}
