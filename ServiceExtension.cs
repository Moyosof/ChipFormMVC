using ChipsForm.Data;
using ChipsForm.Repository.Implementation;
using ChipsForm.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ChipsForm.Infrastructure.Interface;
using ChipsForm.Infrastructure;
using Microsoft.AspNetCore.Http.Features;

namespace ChipsForm
{
    public static class ServiceExtension
    {
        #region DATA CONTEXT
        public static void ConfigureConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer
            (configuration.GetConnectionString("DefaultConnection")));
        }
        #endregion

        #region INTERFACE CONFIGURATION
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IFormService, FormService>();

            services.AddLogging(configure =>
            {
                configure.SetMinimumLevel(LogLevel.Information);
                configure.AddConsole();
            });

            services.Configure<FormOptions>(op =>
            {
                op.MultipartBodyLengthLimit = 20_971_520;
            });
        }
        #endregion
    }
}
