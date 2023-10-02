using HNGxVideoStreaming.BackgroundServices;
using HNGxVideoStreaming.Data;
using HNGxVideoStreaming.Interface;
using HNGxVideoStreaming.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder
                .Configuration
                .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VideoSteamApiDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IWhisperService, WhisperService>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddHostedService<CleanupBackgroundService>();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
