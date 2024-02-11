using PostManager.Api;
using PostManager.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddPresentation()
   .AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
