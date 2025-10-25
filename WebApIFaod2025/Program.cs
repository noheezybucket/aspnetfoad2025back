using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Helpers;
using NLog;
using WebApIFaod2025.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using WebApIFaod2025.Services;



var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));



// Add services to the container.
builder.Services.AddDbContext<bdTracking01Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("connDbTracting")));
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.ConfigureLoggerService();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(typeof(AutoMapperProfile));
});

builder.Services.AddScoped<IUsersColisService, UsersColisService>();
builder.Services.AddTransient<IUsersColisService, UsersColisService>();

var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
else
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
