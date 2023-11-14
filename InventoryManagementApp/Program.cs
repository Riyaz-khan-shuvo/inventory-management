using System.Reflection;
using InventoryManagement.Service.Dependency;
using InventoryManagement.Sql.DbDependencies;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var WebAppCorsPolicy = "WebAppCorsPolicy";

// Add services to the container.

builder.Services.AddDataProtection();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Inventory Management App API",
        Version = "v1",
        Description = "Inventory Management App"
    });
    var path = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xpath = Path.Combine(AppContext.BaseDirectory, path);
    c.IncludeXmlComments(xpath);
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddControllers().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    jsonOptions.SerializerSettings.Formatting = Formatting.Indented;
    jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
});
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContextDependencies(builder.Configuration);
builder.Services.AddServiceDependency(builder.Configuration);
builder.Services.AddRepositoryDependency();
builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression();
var origins = builder.Configuration.GetSection("Domain").Get<Domain>();
if (origins.Client2.Any()) origins.Client1?.AddRange(origins.Client2);

builder.Services.AddCors(options =>
{
    options.AddPolicy(WebAppCorsPolicy,
        policyBuilder => policyBuilder.WithOrigins(origins.Client1.ToArray())
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Management App"); });
}

app.UseResponseCaching();
app.UseResponseCompression();
app.UseCors(WebAppCorsPolicy);
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllers();

app.Run();