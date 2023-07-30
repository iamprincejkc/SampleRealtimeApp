using Microsoft.AspNetCore.SignalR;
using SampleRealtimeApp.Contracts;

namespace SampleRealtimeApp.Hubs
{
    public class ProductHub : Hub<IProductHub>
    {
        public async Task SendProduct(string name, string description, string status, string actionType)
        {
            await Clients.All.ReceiveProduct(name, description, status, actionType);
            //await Clients.User("User Id Here").ReceiveProduct(name, description, status, actionType);
            //await Clients.Groups("Group Name Here").ReceiveProduct(name, description, status, actionType);
        }
    }
}
