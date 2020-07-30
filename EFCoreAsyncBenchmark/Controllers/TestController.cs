using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAsyncBenchmark.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly EntityDbContext _dbContext;

        public TestController(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            for (int i = 0; i < 10; i++)
                await _dbContext.DbEntity.FirstOrDefaultAsync();

            return Ok();
        }

        [HttpGet("blocking")]
        public Task<IActionResult> GetBlocking()
        {
            for (int i = 0; i < 10; i++)
                _dbContext.DbEntity.FirstOrDefault();

            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
