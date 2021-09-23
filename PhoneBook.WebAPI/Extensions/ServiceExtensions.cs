using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Data.Contracts;
using PhoneBook.Data.Models;
using PhoneBook.Data.Repositories;
using PhoneBook.Logic.Managers;

namespace PhoneBook.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePostgresContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<phonebookContext>(o => o.UseNpgsql(config["npgsqlConnString:connectionString"]));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddPhoneBookManager(this IServiceCollection services)
        {
            services.AddScoped<PhoneBookManager>();
        }
    }
}
