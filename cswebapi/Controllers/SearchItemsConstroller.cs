using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cswebapi.Models;

namespace cswebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchItemsController : ControllerBase
    {
        private readonly SearchItemsContext _context;
     

        public SearchItemsController(SearchItemsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchItem>>> GetSearchItems(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return NoContent();
            return await _context.SearchItems.Where(i => i.Name.StartsWith(prefix)).Take(5).OrderBy(s => s.Name).ToListAsync();
        }

        [HttpGet]
        [Route("/api/contains")]
        public async Task<ActionResult<IEnumerable<SearchItem>>> Contains(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return NoContent();
            return await _context.SearchItems.Where(i => i.Name.Contains(prefix)).Take(20).OrderBy(s => s.Name).ToListAsync();
        }


    }
}
