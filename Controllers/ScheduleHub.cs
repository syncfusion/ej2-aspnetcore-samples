using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2ScheduleSample.Controllers
{
    public class ScheduleHub:Hub
    {
        public async Task SendData(string action, object data)
        {
            await Clients.All.SendAsync("ReceiveData", action, data);
        }
    }
}
