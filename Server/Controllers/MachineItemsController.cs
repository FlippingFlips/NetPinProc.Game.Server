using Microsoft.AspNetCore.Mvc;
using NetPinProc.Domain.MachineConfig;
using NetPinProc.Game.Sqlite;

namespace NetPinProc.Game.Manager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineItemsController : ControllerBase
    {
        private readonly ILogger<MachineItemsController> _logger;
        private readonly INetProcDbContext _netProcDb;

        public MachineItemsController(ILogger<MachineItemsController> logger, INetProcDbContext netProcDb)
        {
            _logger = logger;
            _netProcDb = netProcDb;
        }

        /// <summary>
        /// Gets all the switches in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("Switches")]
        public IEnumerable<SwitchConfigFileEntry> Switches()
        {
            return _netProcDb.Switches;
        }

        [HttpGet("Coils")]
        public IEnumerable<CoilConfigFileEntry> Coils()
        {
            return _netProcDb.Coils;
        }

        [HttpGet("Leds")]
        public IEnumerable<LedConfigFileEntry> Leds()
        {
            return _netProcDb.Leds;
        }

        [HttpGet("Lamps")]
        public IEnumerable<LampConfigFileEntry> Lamps()
        {
            return _netProcDb.Lamps;
        }

        [HttpPut("UpdateCoil")]
        public async Task<bool> UpdateCoil([FromBody] CoilConfigFileEntry coilConfig)
        {
            try
            {
                _netProcDb.Coils.Update(coilConfig);
                await _netProcDb.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        [HttpPut("UpdateSwitch")]
        public async Task<bool> UpdateSwitch([FromBody] SwitchConfigFileEntry swConfig)
        {
            try
            {
                _netProcDb.Switches.Update(swConfig);
                await _netProcDb.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
    }
}