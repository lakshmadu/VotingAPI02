using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VotingAPI.DataAccess;
using VotingAPI.Services.Candidates;
using VotingAPI.Services.Parties;
using VotingAPI.Services.Security;
using VotingAPI.Services.Voters;
using VotingAPI.Services.Admins;

var builder = WebApplication.CreateBuilder(args);

//public IConfiguration Configuration { get; }

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;

builder.Services.AddDbContext<VotingDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Connection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IVoterRepository, VoterSqlServerService>();
builder.Services.AddScoped<IPartyRepository, PartySqlserverService>();
builder.Services.AddScoped<IAdminRepository, AdminSqlServerServices>();

builder.Services.AddScoped<ICandidateRepository, CandidateSqlServerService>();

var tokenKey = configuration.GetValue<string>("TokenKey");

var key = Encoding.ASCII.GetBytes(tokenKey);



builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
}
else
{
    app.UseExceptionHandler(app =>
    {
        app.Run(async context =>

        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("There was an error in the server.Please contact developer");
        });
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
