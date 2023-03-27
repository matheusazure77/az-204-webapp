using domain.Applications;
using domain.Repositories;
using domain.Services;
using infra.Applications;
using infra.Repositories;
using infra.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(sqlfunction.SqlFunctionsStartup))]
namespace sqlfunction
{
    public  class SqlFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ISQLAplication, SQLAplication>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddFeatureManagement();
        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var connectionString = "Endpoint=https://webapp-config.azconfig.io;Id=R41t-l0-s0:wkew/Z2SNYqotKPRu0Z5;Secret=Dy93q7PDgqCr7HKeL/HshnL2BrExCpb0pANcNksb9vQ=";
            builder.ConfigurationBuilder.AddAzureAppConfiguration(connectionString);
        }
    }
}
