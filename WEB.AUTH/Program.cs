using Microsoft.EntityFrameworkCore;
using WEB.AUTH.DAL;
using WEB.AUTH.Managers;
using WEB.AUTH.Managers.Configurations;
using WEB.AUTH.Service;
using WEB.AUTH.DAL.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services for your DbContext
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDal();
builder.Services.AddBLL();
builder.Services.AddJwtAuthentication();
builder.Configuration.BindModel(builder.Services);
builder.Services.AddLogger();
builder.Services.AddLoggerFactory();
builder.Services.AddAuthorizationManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseHttpsRedirection();

app.AddMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();