using PostManager.Api;
using PostManager.Application;
using PostManager.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddPresentation()
   .AddApplication()
   .AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
