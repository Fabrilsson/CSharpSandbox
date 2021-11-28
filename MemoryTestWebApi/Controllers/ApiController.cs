using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MemoryTestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet("bigstringCS")]
        public async Task<String> Get()
        {
            return await Task.FromResult(new String('x', 10 * 1024));
        }
    }
}


