using PostManager.Api;
using PostManager.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddPresentation(builder.Configuration)
   .AddInfrastructure();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
