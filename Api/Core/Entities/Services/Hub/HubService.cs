using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.SignalR;

namespace Api.Core.Services;

public class HubProvider : Hub<IHubProvider>
{
    public async Task SendMessage(Message message)
    {
        await Clients.All.ReceivedMessage(message);
        Console.WriteLine(message);
    }
}