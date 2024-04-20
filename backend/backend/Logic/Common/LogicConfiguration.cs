namespace backend.Logic.Common
{
    public static class LogicCOnfiguration
    {
        public static IServiceCollection ConfigureLogicServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionResolver, SessionResolver>();
            return services;
        }
    }
}
