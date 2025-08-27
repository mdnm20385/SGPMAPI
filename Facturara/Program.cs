        using System.Text;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SGPMAPI.Email;
using SGPMAPI.Interfaces;
using SGPMAPI.Procura;
var builder = WebApplication.CreateBuilder(args);
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
        var validAudiences = builder.Configuration.GetSection("JWT:ValidAudience").Get<string[]>();
var validIssuers = builder.Configuration.GetSection("JWT:ValidIssuer").Get<string[]>();
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidAudiences = validAudiences,
    ValidIssuers = validIssuers,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"] ?? string.Empty))
};
    });
//TypeScriptConverter.Main();
//TypeScriptConverter.Sjm();
//TypeScriptConverter.SGPM();
//ConvertMysql.ConvertJsonToSqlServer();
Pbl.ConnectionString = SqlConstring.GetSqlConstring();
Acesso.NomeChefe = Acesso.PatenteCategoria = "";
builder.Services.AddControllers();
builder.Services.AddControllers().
    AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null).
    AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "SGPM",
    Version = "v1"
}));
builder.Services.AddCors(options => options.AddPolicy("Policy", app =>
{
    app.WithOrigins("http://localhost:4200", "http://localhost:4201", "http://localhost:4202", "http://localhost:4203", "http://localhost:4204", "http://localhost:4205", 
        "http://34.10.20.94:3895/", "http://34.10.20.93:3895/",
        "http://172.20.0.3:3895/", "http://172.23.16.22:4200", "http://5.5.5.2:4200/", "http://192.168.140.1:4200/",
        "http://192.168.190.1:4200/", "http://192.168.80.1:4200/"
            ).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SGPMContext>(options =>
{
    options.UseSqlServer(SqlConstring.GetSqlConstring());
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<InterGeral, ServiceGeral>();
builder.Services.AddScoped<InterfBusca, BuscaService>();
builder.Services.AddScoped<InterfProcesso, ProcessoService>();
builder.Services.AddScoped<InterfEntradaProcesso, EntradaProcessoService>();
builder.Services.AddScoped<InterUsers, Userservice>();
builder.Services.AddScoped<InteEmail, EmailService>();
builder.Services.AddScoped<InteEmailEnviar, EmailServiceEnviar>();
builder.Services.AddScoped<InterfaceProcura, ProcuraServico>();
builder.Services.AddScoped(typeof(GenericService<>));
builder.Services.AddScoped<GenericSearchService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IntermatriculaAluno, MatriculaAlunoServicos>();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Initialize reporting services.
var app = builder.Build();
string uploadsDir = Path.Combine(app.Environment.ContentRootPath, "reports");
if (!Directory.Exists(uploadsDir))
    Directory.CreateDirectory(uploadsDir);




if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISGPM v1"));
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISGPM v1"));
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseCors("Policy");
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "reports")),
    RequestPath = new PathString("/reports")
});
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();
    

