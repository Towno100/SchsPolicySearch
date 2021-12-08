using SchsPolicySearch.InMemoryData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PolicySearchDbContext>();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowFrontEndAppOrigins = "_allowFrontEndAppOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowFrontEndAppOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowFrontEndAppOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
