using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adiciona serviço Jwt Bearer (forma de autenticação)
//Deixar indentado assim:
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Deixar indentado assim:
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando 
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração será validado
        ValidateLifetime = true,

        //Forma de criptografia que valida a chave de autentificação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-code-first-webapi-projeto-healthclinic")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(10),

        //Nome do issuer (de onde esta vindo)
        ValidIssuer = "apiweb.healthclinic.manha",

        //Nome do issuer (para onde esta indo)
        ValidAudience = "apiweb.healthclinic.manha"
    };
});


builder.Services.AddSwaggerGen(options =>
{

    //Adiciona informações sobre a API no Swagger
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

    //Configura o swagger para usar o arquivo XML gerado
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
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
            new string[] {}
        }
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
