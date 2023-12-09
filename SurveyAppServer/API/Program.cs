using DAL;

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SurveyAppServer;

const string allowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

ServicesConfiguration.Initialize(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins(builder.Configuration["FrontendOrigin"]);
        });
});

builder.Services.AddDbContext<SurveyAppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddAppServices();

builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

<<<<<<< HEAD:SurveyAppServer/API/Program.cs
app.UseMiddleware<ExceptionHandlerMiddleware>();
=======
app.UseCors(allowSpecificOrigins);

>>>>>>> bb65c9d (Add CORS policy):SurveyAppServer/Program.cs
app.UseAuthorization();

app.MapControllers();

app.Run();
