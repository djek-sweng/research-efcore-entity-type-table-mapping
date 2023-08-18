var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddShared<AppDbContextTph>("db_tph");

builder.Services.AddControllers().AddSharedApplicationPart();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseShared<AppDbContextTph>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
