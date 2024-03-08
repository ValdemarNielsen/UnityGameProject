/*using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Assets.Scripts.BackEnd
{
   
    public class PlayerHub : Hub
    {
        public async Task UpdatePosition(float x, float y)
        {
            // Broadcast the position to all clients except the sender
            await Clients.Others.SendAsync("ReceivePosition", x, y);
        }
    }

}
*/