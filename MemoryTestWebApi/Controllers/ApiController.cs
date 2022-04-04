using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryTestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private static string _staticString = "this is a static string";

        [HttpGet("staticstringCS")]
        public ActionResult<string> GetStaticString()
        {
            return _staticString;
        }

        [HttpGet("bigstringCS")]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.FromResult(new String('x', 10 * 1024));
        }

        [HttpGet("lohCS")]
        public int GetLOH(int size = 85000)
        {
            return new byte[size].Length;
        }

        private static readonly string TempPath = Path.GetTempPath();

        [HttpGet("fileproviderCS")]
        public void GetFileProvider()
        {
            var fp = new PhysicalFileProvider(TempPath);
            fp.Watch("*.*");
        }

        [HttpGet("arrayCS/{size}")]
        public byte[] GetArray(int size)
        {
            var array = new byte[size];

            var random = new Random();
            random.NextBytes(array);

            return array;
        }
    }
}