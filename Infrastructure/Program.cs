using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
builder.Services.AddDbContext<DataContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("app"));
    }
);
*/

app.Run();