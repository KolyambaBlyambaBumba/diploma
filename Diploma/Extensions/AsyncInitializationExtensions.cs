using Extensions.Hosting.AsyncInitialization;

namespace Diploma.Extensions
{
	public static class AsyncInitializationExtensions
	{
		public static IServiceCollection AddAsyncInitializer(this IServiceCollection services, Func<IServiceProvider, Task> initializer)
		{
			_ = services ?? throw new ArgumentNullException(nameof(services));
			_ = initializer ?? throw new ArgumentNullException(nameof(initializer));

			return services.AddAsyncInitializer(sp => new DelegateAsyncInitializer(sp, initializer));
		}

		private sealed class DelegateAsyncInitializer : IAsyncInitializer
		{
			private readonly IServiceProvider serviceProvider;
			private readonly Func<IServiceProvider, Task> func;

			public DelegateAsyncInitializer(IServiceProvider serviceProvider, Func<IServiceProvider, Task> func)
			{
				this.serviceProvider = serviceProvider;
				this.func = func;
			}

			public Task InitializeAsync() => func(serviceProvider);
		}
	}
}