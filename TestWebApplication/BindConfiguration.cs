namespace TestWebApplication
{
	public static class Configuration
	{
		public static void Bind(ref WebApplicationBuilder builder, object?[] instance)
		{
#pragma warning disable CS8604, CS8602
			foreach (var service in instance)
				builder.Configuration.Bind(service.ToString(), service);
		}
	}
}
