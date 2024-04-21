using Neo4j.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(GraphDatabase.Driver(
    builder.Configuration["Neo4j:Remote"], 
    AuthTokens.Basic(
        builder.Configuration["Neo4j:Username"], 
        builder.Configuration["Neo4j:Password"]))
    .AsyncSession(o => o.WithDatabase(builder.Configuration["Neo4j:Database"]))
);
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
