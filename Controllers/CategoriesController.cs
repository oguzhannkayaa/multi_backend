using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiBackend.Entities;
using System.Collections.Generic;

namespace MultiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private DataContext _context;
        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Category>> Get()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }

    }
}
