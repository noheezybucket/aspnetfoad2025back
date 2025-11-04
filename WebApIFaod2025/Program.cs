using Microsoft.EntityFrameworkCore;
using WebApIFaod2025.Helpers;
using NLog;
using WebApIFaod2025.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using WebApIFaod2025.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens.Experimental;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WebApIFaod2025.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));



// Add services to the container.
builder.Services.AddDbContext<bdTracking01Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("connDbTracting")));
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

// For Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:connDbTracting"]));
// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>() 
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IUsersColisService, UsersColisService>();
builder.Services.AddScoped<IColisService, ColisService>();
builder.Services.AddScoped<IDemandeColisService, DemandeColisService>();
builder.Services.AddScoped<ISuiviCommandeService, SuiviCommandeService>();
builder.Services.AddScoped<IListeColisService, ListeColisService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddScoped<ILivraisonService, LivraisonService>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{ 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})


// Adding Jwt Bearer
.AddJwtBearer(options =>
{
options.SaveToken = true;
options.RequireHttpsMetadata = false;
options.TokenValidationParameters = new TokenValidationParameters(){
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ClockSkew = TimeSpan.Zero,
    ValidAudience = configuration["JWT:ValidAudience"],
    ValidIssuer = configuration["JWT:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
};

});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// === DANS builder.Services ===
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Colis", Version = "v1" });

    // AJOUTE ÇA POUR JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Colis v1");
        c.RoutePrefix = "swagger";

        // AJOUTE ÇA POUR LE BOUTON AUTHORIZE
        c.OAuthClientId("swagger");
        c.OAuthUsePkce();
    });

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();  // <-- IMPORTANT
app.UseAuthorization();   // <-- IMPORTANT


app.MapControllers();

app.Run();
