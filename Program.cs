using Employee_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Employee_Management_System.Repository;
using Employee_Management_System.Service;
using Microsoft.Extensions.Options;
using Employee_Management_System.IAuth;
using Employee_Management_System.AuthRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IAuthRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticateService, Authentication>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("AllowAllOrigins");

app.UseDeveloperExceptionPage();

app.MapControllers();

app.Run();
