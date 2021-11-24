using Microsoft.EntityFrameworkCore;
using VotingAPI.DataAccess;
using VotingAPI.Services.Candidates;
using VotingAPI.Services.Parties;
using VotingAPI.Services.Voters;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<ICandidateRepository, CandidateSqlServerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseCors(options =>
    //options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
