using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", // Frontend adresiniz buraya
                                             "http://localhost:4200",
                                             "http://127.0.0.1:5500") // VS Code Live Server vb.
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

// Health check endpoint - base URL için
app.MapGet("/", () => "healthy");

app.MapControllers();

app.Run();
