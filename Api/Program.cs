using Api.AppConfiguration;
using Api.Configuration;
using Api.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services
    .AddEndpointsApiExplorer()
    .ConfigureJwt(builder.Configuration)
    .ConfigureRepositoriesEntities()
    .ConfigureAddons()
    .ConfigureEntitiesServices()
    .ConfigureDatabase(builder.Configuration);

builder.Services.AddSignalR(); 
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseWebSockets();
app.UseAuthorization();
app.MapControllers();
app.MapHub<HubProvider>("/ConnectHub/api/hub");
app.UseHttpsRedirection();
app.Run();
