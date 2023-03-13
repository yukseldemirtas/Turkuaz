using Autofac;
using Turkuaz_WebAPI.Services.Abstract;
using Turkuaz_WebAPI.Services.Concrete;

namespace Turkuaz_WebAPI.Extensions.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AplicationServices>().As<IAplicationServices>();

		}
	}
}
