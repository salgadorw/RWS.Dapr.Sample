using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using API.DI;
using API.Middleware;
using Application.Mapping;

namespace API;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "RWS Gaming API", Version = "v1" });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "RWS.Api.xml"));
        });
        services.AddAutoMapper(x => x.AddMaps(typeof(MapperProfile).Assembly));
        
        services.AddHttpContextAccessor();
        IConfiguration configuration = services.BuildServiceProvider()
                                               .GetService<IConfiguration>();
        services.AddAPIGatewayDependencies(configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "RWS Gaming API v1");
            c.DocExpansion(DocExpansion.List);
        });

        app.UseMiddleware<RequiredHeadersChecker>();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
