
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ===== Add Database ===============================
builder.Services.ConfigureConnectDB(builder.Configuration.GetConnectionString("CmsConnection"));
// ===== Add Database Auth===========================
builder.Services.ConfigureConnectDBAuth(builder.Configuration.GetConnectionString("AuthConnection"));
// ===== Add Services Transient Repository===========
builder.Services.ConfigureServices();
ServiceProvider? provider = builder.Services.BuildServiceProvider();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyName", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowedToAllowWildcardSubdomains());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("PolicyName");
var routing = new RoutingWrapper(app, provider);

routing.MapAll();



app.Run();

