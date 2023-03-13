using Autofac.Extensions.DependencyInjection;
using Autofac;
using FluentValidation.AspNetCore;
using System.Reflection;
using Turkuaz_WebAPI.Extensions.DependencyResolvers.Autofac;
using Serilog;
using Serilog.Formatting.Compact;
using Turkuaz_WebAPI.Extensions.Exceptions.ExceptiHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(cBuilder =>
	{
		cBuilder.RegisterModule(new AutofacBusinessModule());
	});

builder.Services.AddFluentValidation(options =>
{
	options.ImplicitlyValidateChildProperties = true;
	options.ImplicitlyValidateRootCollectionElements = true;
	options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
	configuration.WriteTo.File(new RenderedCompactJsonFormatter(), "logs/logs.txt", rollingInterval: RollingInterval.Day);
});


builder.Services.AddControllers();
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
app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
