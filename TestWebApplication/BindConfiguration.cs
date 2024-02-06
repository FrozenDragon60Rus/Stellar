using System.Reflection;
using TestWebApplication.Service;

namespace TestWebApplication
{
	public class BindConfiguration
	{
		public BindConfiguration(ref WebApplicationBuilder builder, object?[] instance)
		{
			foreach (var service in instance)
				builder.Configuration.Bind(service.ToString(), service);
		}
	}
}
