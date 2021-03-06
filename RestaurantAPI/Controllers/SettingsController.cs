using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using System.Linq;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("settings")]

    public class SettingsController : ControllerBase
    {


        private readonly RestaurantsContext _context;

        public SettingsController(RestaurantsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<Settings> Get()
        {
            Settings allSettings = await _context.Settings.FirstOrDefaultAsync();
            return allSettings;
        }

        [HttpPut]
        public async Task<Settings> Put(Settings updateSetting)
        {
            _context.Update(updateSetting);
            await _context.SaveChangesAsync();
            return updateSetting;
        }

        [HttpPost]
        public async Task<Settings> Post(Settings newSettings)
        {
            _context.Settings.Add(newSettings);
            await _context.SaveChangesAsync();
            return newSettings;
        }
    }

}