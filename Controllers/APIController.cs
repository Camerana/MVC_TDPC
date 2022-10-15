using Microsoft.AspNetCore.Mvc;
using MVC_TDPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_TDPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet("GetListaStringhe")]
        public async Task<List<string>> GetListaStringhe()
        {
            List<string> result = new List<string>()
            {
                "stringa 1",
                "stringa 2"
            };

            //qui posso mettere await se voglio aspettare
            await Task.Run(() =>
            {
                //Thread.Sleep(5000);
                result = new List<string>() {
                "stringa async 1",
                "stringa async 2"
                  };
            });
            return result;
        }
        [HttpGet("GetDDLValue")]
        public async Task<object> GetDDLValue(int id)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();
            values.Add(0, "zero");
            values.Add(1, "uno");
            values.Add(2, "due");
            return new
            {
                Value = values[id]
            };
        }
    }
}