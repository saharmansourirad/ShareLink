using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));




//Config the services

builder.Services.AddTransient<PostsService>();
builder.Services.AddTransient<CommentsService>();
builder.Services.AddTransient<UsersService>();
builder.Services.AddTransient<LikesService>();
builder.Services.AddTransient<TagsService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
