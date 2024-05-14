using ExchangeOffice.Application.Extensions;
using ExchangeOffice.Common.Extensions;
using ExchangeOffice.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddJwtAuth();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

	// Добавление аутентификации в Swagger
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
		Description = "JWT Authorization header using the Bearer scheme",
		Type = SecuritySchemeType.Http,
		Scheme = "bearer"
	});

	// Добавление политики безопасности для Swagger
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
				new string[] { }
			}
		});
});
builder.Services.AddApplicationLayer();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin",
		builder => {
			builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

var app = builder.Build();
app.UseGlobalErrorHandling();

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseAuthorization();


app.MapControllers();
app.UseCors("AllowAnyOrigin");

app.Run();
