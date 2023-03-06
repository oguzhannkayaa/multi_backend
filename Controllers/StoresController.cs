using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiBackend.Entities;

namespace MultiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private DataContext _context;
        public StoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Store>> GetStores()
        {
            var stores = await _context.Stores.OrderBy(x => x.StoreName).ToListAsync();

            return stores;
        }

        [HttpGet("{name}")]
        public async Task<List<Store>> GetStoresByNames(string name)
        {
            var stores = await _context.Stores.Where(c => c.StoreName.ToLower().Contains(name.ToLower())).OrderBy(x => x.StoreName).ToListAsync();

            return stores;
        }
    }
}
