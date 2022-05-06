using System.Text;

using DNZ.API;
using DNZ.API.AutoMapper;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DNZ.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
