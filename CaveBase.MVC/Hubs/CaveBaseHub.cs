using CaveBase.Library.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.MVC.Hubs
{
    public class CaveBaseHub : Hub
    {
        public async Task UpdateCountry(Country newcountry, Country oldCountry, string message)
        {
            await Clients.All.SendAsync("ReceiveUpdateCountry", newcountry, oldCountry, message);
        }
    }
}