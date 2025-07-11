using Adapter.MongoDB;
using Adapter.MongoDB.Repositories;
using backend.Core;

var builder = WebApplication.CreateBuilder(args);
IConfiguration conectionString = builder.Configuration;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped(_ => new MongoDbContext(conectionString));
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyRepository, MongoPropertyRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin()));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MongoDbContext>();
    DataSeeder.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// allow all cors in Development
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => "Hello Millions!");

app.Run();
