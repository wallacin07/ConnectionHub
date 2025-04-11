using Api.Domain.Models;

namespace Api.Domain.Services;

public interface IHubProvider
{
    Task ReceivedMessage(Message message);

}