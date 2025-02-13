namespace CreditCard.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependecy(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            
            return services;
        }
    }
}
