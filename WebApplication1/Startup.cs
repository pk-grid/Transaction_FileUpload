// Define the startup class
public class Startup
{
    // Method to configure services
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the transaction service
        services.AddTransient<TransactionService>();

        // Add the transaction controller
        services.AddControllers();
    }

    // Method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Use the developer exception page
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Use routing
        app.UseRouting();

        // Use endpoint routing
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}