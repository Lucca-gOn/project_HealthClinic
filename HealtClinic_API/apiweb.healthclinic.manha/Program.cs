using apiweb.healthclinic.manha.Interfaces;
using apiweb.healthclinic.manha.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.

builder.Services.AddControllers();

// Aqui você registra as implementações dos seus repositórios
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IMedicoServiceRepository, MedicoServiceRepository>();

// Adiciona o serviço de autenticação JWT Bearer.
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
        Description = "API para o gerenciamentos de consultas médicas - HealthClinic WEB.API",
        Contact = new OpenApiContact
        {
            Name = "Lucas Oliveira - Senai Informática",
            Url = new Uri("https://github.com/Lucca-gOn")
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

    // Adiciona um filtro de operação para suportar o upload de arquivos no Swagger UI
    options.OperationFilter<FileUploadOperation>();
});

// Adiciona o serviço de exploração de API para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Adiciona o serviço SwaggerGen com configurações definidas
// Removemos a chamada duplicada que estava aqui

var app = builder.Build();

// Configura o pipeline de requisições HTTP.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// A ordem correta é usar primeiro a autenticação e depois a autorização.
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Implementação do filtro de operação para upload de arquivos
public class FileUploadOperation : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasFormData = operation.RequestBody?.Content.Any(x => x.Key.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase));
        if (hasFormData == true)
        {
            var formDataContent = operation.RequestBody.Content["multipart/form-data"];

            // Verifica se a chave 'file' já existe antes de adicioná-la
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



