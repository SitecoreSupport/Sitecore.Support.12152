using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.JsonVariants.Renderers;

namespace Sitecore.Support
{
  public class RegisterSupportJsonVariantsServices : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IJsonRendererFactory, Sitecore.Support.XA.Foundation.JsonVariants.Renderers.JsonRendererFactory>();
    }
  }
}