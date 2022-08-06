using API;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var appConnection = builder.Configuration.GetConnectionString("appConnection");
// Add services to the container.
 
builder.Services.AddDbContext<Data.AppContext>(options =>
{
    options.UseSqlServer(appConnection, op => op.MigrationsAssembly("Data"));
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders();

//builder.Services.AddIdentityServer().AddAspNetIdentity<IdentityUser>().AddConfigurationStore(options =>
//{
//    options.ConfigureDbContext = b => b.UseSqlServer(appConnection, x => x.MigrationsAssembly("Data"));
//}).AddOperationalStore(options =>
//{
//    options.ConfigureDbContext = b => b.UseSqlServer(appConnection, x => x.MigrationsAssembly("Data"));
//}).AddDeveloperSigningCredential();
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(ConfigIdentityServer.GetIdentityResources())
    .AddInMemoryClients(ConfigIdentityServer.GetClaims());

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
