using Microsoft.AspNetCore.Mvc;
using NetPinProc.Game.Sqlite;
using NetPinProc.Game.Sqlite.Model;

namespace NetPinProc.Game.Manager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : NetProcBaseController
    {
        public PlayersController(ILogger<PlayersController> logger, INetProcDbContext netProcDb) : base(logger, netProcDb)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> Get() 
        {
            return _netProcDb.Players.ToList();
        }
    }
}
