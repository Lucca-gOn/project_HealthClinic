using apiweb.healthclinic.manha;
using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using apiweb.healthclinic.manha.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:3000")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});

// Registra as implementaçoes dos seus repositorios
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<ITiposUsuarioRepository, TiposUsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IImagemService, ImagemService>();
builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>();
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

string x = builder.Configuration["ConnectionStrings:Default"];

builder.Services.AddDbContext<HealthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Adiciona o servi�o de autentica��o JWT Bearer.
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-code-first-webapi-projeto-healthclinic")),
        ClockSkew = TimeSpan.FromMinutes(10),
        ValidIssuer = "apiweb.healthclinic.manha",
        ValidAudience = "apiweb.healthclinic.manha"
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API HealthClinic",
        Description = "API Para Gerenciamento de Consultas Médicas - HealthClinic WEB.API",
        Contact = new OpenApiContact
        {
            Name = "Lucas Oliveira E Paulo Oliveira - Senai Informática",
            Url = new Uri("https://github.com/MagiLogus/HealthClinic")
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta maneira: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });

    // Adiciona um filtro de opera��o para suportar o upload de arquivos no Swagger UI
    options.OperationFilter<FileUploadOperation>();
    options.CustomSchemaIds(type => type.ToString());
});

// Adiciona o servi�o de explora��o de API para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Adiciona o servi�o SwaggerGen com configura��es definidas
// Removemos a chamada duplicada que estava aqui

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

// A ordem correta � usar primeiro a autentica��o e depois a autoriza��o.
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Configuração do middleware para servir arquivos estáticos.
app.UseStaticFiles();

//app.Urls.Add("http://192.168.15.7:5000"); // CASA
app.Urls.Add("http://172.16.35.116:5000");  //SENAI TECNICO
//app.Urls.Add("http://172.16.26.30:5000");  //SENAI CODE

app.Run();

//Implementa��o do filtro de opera��o para upload de arquivos
public class FileUploadOperation : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasFormData = operation.RequestBody?.Content.Any(x => x.Key.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase));
        if (hasFormData == true)
        {
            var formDataContent = operation.RequestBody.Content["multipart/form-data"];

            // Verifica se a chave 'file' j� existe antes de adicion�-la
            if (!formDataContent.Schema.Properties.ContainsKey("file"))
            {
                formDataContent.Schema.Properties.Add("file", new OpenApiSchema
                {
                    Description = "Upload File",
                    Type = "string",
                    Format = "binary"
                });
            }
        }
    }
}



