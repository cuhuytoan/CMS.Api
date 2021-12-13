
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ===== Add Database ===============================
builder.Services.ConfigureConnectDB(builder.Configuration.GetConnectionString("CmsConnection"));
// ===== Add Database Auth===========================
builder.Services.ConfigureConnectDBAuth(builder.Configuration.GetConnectionString("AuthConnection"));
// ===== Config Identity=============================
// ===== Add Identity ========
// ===== Add Identity ========
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// ===== Config Identity ========
builder.Services.ConfigureIdentity();
// ===== Add Services Transient Repository===========
builder.Services.ConfigureServices();
// ===== Add Services Transient Repository Wrapper===
builder.Services.AddTransient<IRepositoryWrapper,RepositoryWrapper>();
// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
        ValidAudience = builder.Configuration["AppSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyName", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowedToAllowWildcardSubdomains());
});

var provider = builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors("PolicyName");

var routing = new RoutingWrapper(app, provider);

routing.MapAll();

app.Run();

