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

        public async Task UpdateClub(Club newClub, Club oldClub, string message)
        {
            await Clients.All.SendAsync("ReceiveUpdateClub", newClub, oldClub, message);
        }

        public async Task UpdateCaver(Caver newCaver, Caver oldCaver, string message)
        {
            await Clients.All.SendAsync("ReceiveUpdateCaver", newCaver, oldCaver, message);
        }

        public async Task UpdateCave(Cave newCave, Cave oldCave, string message)
        {
            await Clients.All.SendAsync("ReceiveUpdateCave", newCave, oldCave, message);
        }


    }
}