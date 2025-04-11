namespace Api.Domain.Models;

public class Message
{
    public string Name { get; set; }
    public  string Body { get; set; }

    public string Token { get; set; }
    public string Date { get; set; }

    public Message(string name, string body, string token)
    {
        Name = name;
        Body = body;
        Token = token;
        Date = DateTime.Now.ToString("G");
    }
}